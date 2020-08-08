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
    public partial class Form_Assign_Card : Form
    {

        public Form_Assign_Card()
        {
            InitializeComponent();
        }
        DataTable dt_Customer = new DataTable("Customer");
        private void Form_Assign_Card_Load(object sender, EventArgs e)
        {
            // Disconnect
            string str_cmd = "select * from view_customer_no_card;";
            string str_con = "Server=.;Database=Test1;Integrated Security=SSPI;";
            SqlDataAdapter adapter = new SqlDataAdapter(str_cmd, str_con);
            adapter.Fill(dt_Customer);
            cboCustomer.DataSource = dt_Customer;
            cboCustomer.DisplayMember = "CName";
            cboCustomer.ValueMember = "CID";

            //Connected
            //string str_cmd = "select * from view_customer_no_card;";
            //string str_con = "Server=.;Database=Test1;Integrated Security=SSPI;";
            //SqlCommand cmd = new SqlCommand(str_cmd, new SqlConnection(str_con));
            //cmd.Connection.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    BindingSource bs = new BindingSource();
            //    bs.DataSource = reader;
            //    cboCustomer.DataSource = bs;
            //    cboCustomer.DisplayMember = "CName";
            //    cboCustomer.ValueMember = "CID";
            //}
            //cmd.Connection.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str_cmd = @"insert into tbl_Discount_Card(CID,Discount, EndDate, Discription) 
                                values(@cid, @discount, @end_date, @discription)";
            MyConnection myConnection = ConfigurationHelper.Read<MyConnection>();
            string str_con = myConnection.ToString();
            SqlCommand cmd = new SqlCommand(str_cmd, new SqlConnection(str_con));
            cmd.Parameters.AddWithValue("@cid", (int)cboCustomer.SelectedValue);
            cmd.Parameters.AddWithValue("@discount", decimal.Parse(txtDiscount.Text.Trim()));
            cmd.Parameters.AddWithValue("@end_date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@discription", txtDiscription.Text.Trim());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            MessageBox.Show("ទិន្ន័យត្រូវបានបញ្ចូលរួចរាល់");
            //delete
            dt_Customer.Select("CID=" + cboCustomer.SelectedValue.ToString()).First().Delete();
            //Clear
            cboCustomer.SelectedIndex = -1;
            txtDiscount.Clear();
            txtDiscription.Clear();
            dateTimePicker1.Value = DateTime.Now;

        }
    }
}
