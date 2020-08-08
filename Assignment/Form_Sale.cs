using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace Assignment
{
    public partial class Form_Sale : Form
    {
        public Form_Sale()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        DataSet ds = new DataSet();
        private void Form_Sale_Load(object sender, EventArgs e)
        {
            //Staff
            lblStaff.Text = Program.staff_name;
            //Customer
            string str_cmd = "select CID, CName from tbl_customer;";
            SqlDataAdapter adapter_Customer = new SqlDataAdapter(str_cmd, Program.Connection);
            adapter_Customer.Fill(ds, "Customer");
            cboCustomer.SelectedIndexChanged -= cboCustomer_SelectedIndexChanged;
            cboCustomer.DataSource = ds.Tables["Customer"];
            cboCustomer.DisplayMember = "CName";
            cboCustomer.ValueMember = "CID";
            cboCustomer.SelectedIndex = -1;
            cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;
            if (ds.Tables["Customer"].Rows.Count > 0)
                cboCustomer.SelectedIndex = 0;
            //Invoice Detail
            DataTable dt_invoice_detail = new DataTable("Invoice_Detail");
            dt_invoice_detail.Columns.Add("PID", typeof(int));
            dt_invoice_detail.Columns.Add("PName", typeof(string));
            dt_invoice_detail.Columns.Add("Qty", typeof(int));
            dt_invoice_detail.Columns.Add("Unit_Price", typeof(double));
            dt_invoice_detail.Columns.Add("Total_Price", typeof(double));
            dt_invoice_detail.Columns["Total_Price"].Expression = "Qty * Unit_Price";
            ds.Tables.Add(dt_invoice_detail);
            dataGridView1.DataSource = ds.Tables["Invoice_Detail"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 50;
            //
            DataGridViewImageColumn btn_delete = new DataGridViewImageColumn();
            btn_delete.Image = Properties.Resources.Minus_104px;
            btn_delete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(btn_delete);
            dataGridView1.Columns[5].Width = 30;
            //
            //Category
            string str_category = "select CategoryName from tbl_Category;";
            SqlDataAdapter adapter_category = new SqlDataAdapter(str_category, Program.Connection);
            adapter_category.Fill(ds, "Category");
            foreach (DataRow row in ds.Tables["Category"].Rows)
            {
                Button btn = new Button();
                btn.Text = row[0].ToString();
                btn.Width = flowLayoutPanel_Category.Width - 3;
                btn.Height = 35;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.SeaGreen;
                btn.ForeColor = Color.White;
                btn.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                btn.Margin = new Padding(1);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Click += Btn_Click;
                flowLayoutPanel_Category.Controls.Add(btn);
            }
            //Generate New Invoice ID
            lblInvoiceID.Text = this.GenerateAutoInvoiceID();
        }

        string GenerateAutoInvoiceID()
        {
            SqlCommand cmd = new SqlCommand("sp_GenerateAutoInvoiceID", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp_INVID = new SqlParameter("@generated_id", SqlDbType.VarChar, 10);
            sp_INVID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp_INVID);
            Program.Connection.Open();
            cmd.ExecuteNonQuery();
            Program.Connection.Close();
            return sp_INVID.Value.ToString();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //Load Product
            string cate_name = (sender as Button).Text;//Tea
            string str_product = "select * from tbl_product where Category = @cate_name;";
            SqlDataAdapter adapter_product = new SqlDataAdapter(str_product, Program.Connection);
            adapter_product.SelectCommand.Parameters.AddWithValue("@cate_name", cate_name);
            if (ds.Tables.Contains("Product"))
                ds.Tables["Product"].Clear();
            adapter_product.Fill(ds, "Product");
            //Add to Form
            flowLayoutPanel_Product.Controls.Clear();
            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                UserControl_Product ucp = new UserControl_Product();
                int width = (int)flowLayoutPanel_Product.Width / 6;
                ucp.Width = width;
                ucp.Height = width + 20;
                ucp.Product_Name.Text = row[2].ToString();
                ucp.Tag = row;
                MemoryStream mem = new MemoryStream((byte[])row[7]);
                ucp.Product_Picture.BackgroundImage = Image.FromStream(mem);
                ucp.Product_Picture.BackgroundImageLayout = ImageLayout.Stretch;
                //
                ucp.Product_Picture.Click += Product_Picture_Click;
                //
                flowLayoutPanel_Product.Controls.Add(ucp);
            }
        }

        private void Product_Picture_Click(object sender, EventArgs e)
        {
            DataRow row_product = (DataRow)((sender as Button).Parent as UserControl_Product).Tag;
            int pid = (int)row_product[0];
            DataRow row_invoice;
            row_invoice = ds.Tables["Invoice_Detail"].Select("PID=" + pid).FirstOrDefault();
            if (row_invoice != null)
            {
                row_invoice[2] = (int)row_invoice[2] + 1;
            }
            else
            {
                row_invoice = ds.Tables["Invoice_Detail"].NewRow();
                row_invoice[0] = row_product[0];//Product ID
                row_invoice[1] = row_product[2];//Product Name
                row_invoice[2] = 1;//Qty
                row_invoice[3] = (decimal)row_product[5];//Price
                ds.Tables["Invoice_Detail"].Rows.Add(row_invoice);
            }
            //Calculate Price
            this.CalculatePrice();
        }
        void CalculatePrice()
        {
            double total_qty = 0;
            double total_price = 0;
            double payment = 0;
            double discount = 0;
            double.TryParse(txtDiscount.Text.Trim().Remove(txtDiscount.TextLength - 1), out discount);
            discount /= 100;
            //Linq with Method Syntax
            total_qty = (int)ds.Tables["Invoice_Detail"].AsEnumerable().Sum(qty => qty.Field<int>("Qty"));
            total_price = (double)ds.Tables["Invoice_Detail"].AsEnumerable().Sum(tp => tp.Field<double>("Total_Price"));
            payment = total_price - (total_price * discount);
            txt_Total_Qty.Text = total_qty.ToString();
            txt_Total_Price.Text = total_price.ToString("0.00");
            txt_Payment.Text = payment.ToString("0.00");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int pid = (int)dataGridView1[0, e.RowIndex].Value;
                DataRow row_invoice;
                row_invoice = ds.Tables["Invoice_Detail"].Select("PID=" + pid).FirstOrDefault();
                if ((int)row_invoice[2] > 1)
                {
                    row_invoice[2] = (int)row_invoice[2] - 1;
                }
                else
                {
                    row_invoice.Delete();
                }
                this.CalculatePrice();
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal discount = 0;
                string str_cmd = @"select dc.Discount
                                from tbl_Customer as c inner join tbl_Discount_Card as dc
                                on c.CID = dc.CID
                                where c.CID = @cid;";
                SqlCommand cmd = new SqlCommand(str_cmd, Program.Connection);
                cmd.Parameters.AddWithValue("@cid", cboCustomer.SelectedValue);
                Program.Connection.Open();
                object result =cmd.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    discount = (decimal)result;
                }
                else
                {
                    discount = 0;
                }
                Program.Connection.Close();
                txtDiscount.Text = discount.ToString("0.##") + "%";
            }
            catch (Exception)
            {
                txtDiscount.Text = "0";
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }

        }

        private void btnSave_and_Print_Click(object sender, EventArgs e)
        {
            try
            {
                //Report//Receipt
                //Microsoft.Reporting.Winforms
                LocalReport lr = new LocalReport();
                lr.ReportPath = Application.StartupPath + @"\Receipt.rdlc";
                lr.SetParameters(new ReportParameter("rp_invoice_id", lblInvoiceID.Text));
                lr.SetParameters(new ReportParameter("rp_Cashier", lblStaff.Text));
                lr.SetParameters(new ReportParameter("rp_customer", cboCustomer.Text));
                lr.SetParameters(new ReportParameter("rp_total", txt_Total_Price.Text));
                lr.SetParameters(new ReportParameter("rp_discount", txtDiscount.Text));
                lr.SetParameters(new ReportParameter("rp_payment", txt_Payment.Text));
                lr.SetParameters(new ReportParameter("rp_print_date", DateTime.Now.ToString("dd/MMM/yyyy hh:mm")));
                //
                string str_cmd_Invoid = "INSERT INTO tbl_Invoice(INVID, CID, SID, Invoice_Date, Total_Price, Discount, Pay_Price) VALUES(@invid, @cid, @sid, @inv_date, @total_price, @discount, @pay);";
                string str_cmd_Invoid_Detail = "INSERT INTO tbl_Invoice_Detail(INVID, PID, qty, unit_price) VALUES(@invid, @pid, @qty, @unit_price);";
                SqlCommand cmd = new SqlCommand("", Program.Connection);

                cmd.Parameters.AddWithValue("@invid", lblInvoiceID.Text);
                cmd.Parameters.AddWithValue("@cid", (int)cboCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", int.Parse(Program.sid));
                cmd.Parameters.AddWithValue("@inv_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@total_price", double.Parse(txt_Total_Price.Text));
                cmd.Parameters.AddWithValue("@discount", decimal.Parse(txtDiscount.Text.Remove(txtDiscount.TextLength - 1)));
                cmd.Parameters.AddWithValue("@pay", decimal.Parse(txt_Payment.Text));
                Program.Connection.Open();
                //Ivoice
                cmd.CommandText = str_cmd_Invoid;
                cmd.ExecuteNonQuery();
                //Invoice Detail
                cmd.CommandText = str_cmd_Invoid_Detail;
                //report cont..
                DataSet1 ds_report = new DataSet1();
                BindingSource bs = new BindingSource();
                bs.DataSource = ds_report;
                bs.DataMember = "Invoice_Detail";
                foreach (DataRow row in ds.Tables["Invoice_Detail"].Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@invid", lblInvoiceID.Text);
                    cmd.Parameters.AddWithValue("@pid", (int)row[0]);
                    cmd.Parameters.AddWithValue("@qty", (int)row[2]);
                    cmd.Parameters.AddWithValue("@unit_price", (double)row[3]);
                    ds_report.Invoice_Detail.AddInvoice_DetailRow(row[1].ToString(), (int)row[2], (double)row[3], (double)row[4]);
                    cmd.ExecuteNonQuery();
                }
                lr.DataSources.Add(new ReportDataSource("DataSet1", bs));
                //Print Invoice
                PrintHelper printer = new PrintHelper();
                printer.Paper = PrintHelper.PapperKind.POS;
                printer.PrinterName = "POS-80";
                printer.Report = lr;
                printer.Print();
                Program.Connection.Close();
                lblInvoiceID.Text = this.GenerateAutoInvoiceID();
                //Clear
                this.flowLayoutPanel_Product.Controls.Clear();
                ds.Tables["Invoice_Detail"].Clear();
                txt_Total_Price.Clear();
                txt_Total_Qty.Clear();
                txt_Payment.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }
    }
}
