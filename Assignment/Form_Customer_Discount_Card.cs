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

namespace Assignment
{
    public partial class Form_Customer_Discount_Card : Form
    {
        public Form_Customer_Discount_Card()
        {
            InitializeComponent();
        }
        DataTable dt_Customer_Card = new DataTable("Customer_Card");
        private void Form_Customer_Discount_Card_Load(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection connection = new SqlConnection("Server=.;Database=Test1;Integrated Security=SSPI;");
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = @"select c.CID, c.CName, c.Gender, c.Phone, ca.Discount, ca.EndDate, ca.Discription from tbl_Customer as c inner join tbl_Discount_Card as ca on c.CID = ca.CID";
                cmd.CommandText = "select * from view_Customer_Card;";
                cmd.Connection = Program.Connection;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt_Customer_Card);
                dataGridView1.DataSource = dt_Customer_Card;

                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                //
                cboCustomer.SelectedIndexChanged -= cboCustomer_SelectedIndexChanged;
                cboCustomer.DataSource = dt_Customer_Card.Copy();
                cboCustomer.DisplayMember = "CName";
                cboCustomer.ValueMember = "CID";
                cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;
                //Total
                lblTotal.Text = "សរុប ៖ " + dt_Customer_Card.Rows.Count;
                //Total Expired
                int total_expired = (int)dt_Customer_Card.Compute("COUNT(EndDate)", "EndDate < #" + DateTime.Now.ToString("MM/dd/yyyy") + "#");
                lblExpiredCard.Text = "ផុតកំណត់ ៖ " + total_expired;
                //Minimum Discount
                decimal min_dis = (decimal)dt_Customer_Card.Compute("MIN(Discount)", "");
                lblLowDiscount.Text = "ភាគរយបញ្ចុះតំលៃទាបបំផុត ៖ " + min_dis;
                //Maximum Discount
                decimal max_dis = (decimal)dt_Customer_Card.Compute("MAX(Discount)", "");
                lblHighDiscount.Text = "ភាគរយបញ្ចុះតំលៃខ្ពស់បំផុត ៖ " + max_dis;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbo_ExpireType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCustomer.SelectedValueChanged -= cboCustomer_SelectedIndexChanged;
            switch (cbo_ExpireType.SelectedIndex)
            {
                case 0://មានសុពលភាព
                    dt_Customer_Card.DefaultView.RowFilter = "EndDate > #" + DateTime.Now.ToString("MM/dd/yyyy") + "#";
                    break;
                case 1://ផុតកំណត់
                    dt_Customer_Card.DefaultView.RowFilter = "EndDate < #" + DateTime.Now.ToString("MM/dd/yyyy") + "#";
                    break;
                case 2://ជិតផុតកំណត់
                    dt_Customer_Card.DefaultView.RowFilter = "EndDate >= #" + DateTime.Now.AddMonths(-3).ToString("MM/dd/yyyy") + "# AND EndDate <= #" + DateTime.Now.ToString("MM/dd/yyyy") + "#";
                    break;
                case 3://បង្ហាញទាំងអស់
                    dt_Customer_Card.DefaultView.RowFilter = "";
                    break;
            }
            cboCustomer.SelectedValueChanged += cboCustomer_SelectedIndexChanged;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cboCustomer.SelectedValue.ToString();//CID
            DataRow row = dt_Customer_Card.Select("CID = " + id).FirstOrDefault();
            if (row != null)
            {
                txtID.Text = row[0].ToString();
                txtName.Text = row[1].ToString();
                txtGender.Text = row[2].ToString();
                txtPhone.Text = row[3].ToString();
                //
                txtDiscount.Text = ((decimal)row[4]).ToString("##.##");
                txtExpireDate.Text = ((DateTime)row[5]).ToString("dd/MM/yyyy");
                txtDiscription.Text = row[6].ToString();
                DateTime exp_date = (DateTime)row[5];
                if (exp_date < DateTime.Now)
                {
                    txtCardState.Text = "ផុតកំណត់";
                    txtCardState.ForeColor = Color.Red;
                }
                else if (exp_date >= DateTime.Now)
                {
                    txtCardState.Text = "មានសុពលភាព";
                    txtCardState.ForeColor = Color.Green;
                }
                else if (exp_date >= DateTime.Now.AddMonths(-3) && exp_date <= DateTime.Now)
                {
                    txtCardState.Text = "ជិតផុតកំណត់";
                    txtCardState.ForeColor = Color.Yellow;
                }

            }
        }
    }
}
