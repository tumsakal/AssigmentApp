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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string str = @"select s.SID, s.StaffName, u.user_role from tbl_Staff as s inner join tbl_User as u on s.SID = u.SID where username = @usr and password = @pwd;";
            try
            {
                SqlCommand cmd = new SqlCommand(str, Program.Connection);
                cmd.Parameters.AddWithValue("@usr", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@pwd", txtPassword.Text.Trim());
                Program.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Program.sid = reader[0].ToString();
                    Program.staff_name = reader[1].ToString();
                    Program.user_role = reader[2].ToString();
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                Program.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
