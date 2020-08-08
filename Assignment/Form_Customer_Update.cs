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
    public partial class Form_Customer_Update : Form
    {
        public int id;
        public Form_Customer_Main frm_main;
        public Form_Customer_Update()
        {
            InitializeComponent();
        }
        DataRow dr;
        private void Form_Customer_Update_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            txtID.Text = id.ToString();
            dr = frm_main.ds.Tables["Customer"].Select("CID=" + id).First();
            txtName.Text = dr[1].ToString();
            cboGender.Text = dr[2].ToString();
            txtPOB.Text = dr[3].ToString();
            txtAddress.Text = dr[4].ToString();
            dateTimePicker_DOB.Value = (DateTime)dr[5];
            txtPhone.Text = dr[6].ToString();
            txtEmail.Text = dr[7].ToString();
            cboType.Text = dr[8].ToString();
            dateTimePicker_Register.Value = (DateTime)dr[9];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dr[1] = txtName.Text.Trim();
            dr[2] = cboGender.Text;
            dr[3] = txtPOB.Text.Trim();
            dr[4] = txtAddress.Text.Trim();
            dr[5] = dateTimePicker_DOB.Value;
            dr[6] = txtPhone.Text.Trim();
            dr[7] = txtEmail.Text.Trim();
            dr[8] = cboType.Text.Trim();
            dr[9] = dateTimePicker_Register.Value;
            frm_main.adapter.Update(frm_main.ds.Tables["Customer"]);
            this.Close();
            //SqlConnection connection = new SqlConnection("Server=.;database=Test1;Integrated Security=SSPI;");
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = connection;
            //cmd.CommandText = "";
            //connection.Open();
            //cmd.ExecuteNonQuery();
            //connection.Close();
        }
    }
}
