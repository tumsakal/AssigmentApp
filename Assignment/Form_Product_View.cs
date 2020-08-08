using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class Form_Product_View : Form
    {
        public Form_Product_View()
        {
            InitializeComponent();

        }
        BindingSource bs = new BindingSource();
        public void Form_Product_View_Load(object sender, EventArgs e)
        {
            try
            {
                MyConnection myConnection = ConfigurationHelper.Read<MyConnection>();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = myConnection.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select * from tbl_Product ;";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    bs.DataSource = reader;
                    dataGridView1.DataSource = bs;
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
                connection.Close();
                //SqlParameter
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtIDCard_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
