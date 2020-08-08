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
    public partial class Form_Extend : Form
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt_Customer = new DataTable("Customer");
        public Form_Extend()
        {
            InitializeComponent();
        }

        private void Form_Extend_Load(object sender, EventArgs e)
        {
            MyConnection myConnection = ConfigurationHelper.Read<MyConnection>();
            connection.ConnectionString = myConnection.ToString();
            cmd.Connection = connection;
            cmd.CommandText = "sp_Get_Customer_Has_Card";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            SqlDataReader read = cmd.ExecuteReader();
            dt_Customer.Load(read);
            cmd.Connection.Close();
            cboCustomer.DataSource = dt_Customer;
            cboCustomer.DisplayMember = "CName";
            cboCustomer.ValueMember = "CID";
            txtEndDate.DataBindings.Add("Text", dt_Customer, "EndDate", true, DataSourceUpdateMode.Never, "", "dd/ MM/ yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Calculate Month to be extend
            int add_month = 0;
            add_month = radioButtonMonth.Checked ? int.Parse(txtExtend.Text.Trim()) : int.Parse(txtExtend.Text.Trim()) * 12;
            //Get Old Date of that Customer
            DateTime new_date;
            DateTime.TryParseExact(txtEndDate.Text.Trim(), "dd/ MM/ yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out new_date);
            //Calculate New Date
            new_date = new_date.AddMonths(add_month);
            //
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE tbl_Discount_Card SET EndDate = @new_date where CID = @cid;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@new_date", new_date);
            cmd.Parameters.AddWithValue("@cid", (int)cboCustomer.SelectedValue);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //
            dt_Customer.Select("CID=" + cboCustomer.SelectedValue.ToString()).First().Delete();
            //
            cboCustomer.SelectedIndex = -1;
            txtEndDate.Clear();
            txtExtend.Clear();
        }
    }
}
