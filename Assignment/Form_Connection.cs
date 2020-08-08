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

namespace Assignment
{
    public partial class Form_Connection : Form
    {
        bool connection_ready = false;
        public string file_name = Program.file_name;
        bool allowClose = false;
        public Form_Connection()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (connection_ready)
            {
                MyConnection conn = new MyConnection();
                conn.Server = txtServer.Text.Trim();
                conn.Database = txtDatabase.Text.Trim();
                conn.User = txtUser.Text.Trim();
                conn.Password = txtPassword.Text.Trim();
                conn.IsWindowsAuthenticationMode = comboBox_LoginMode.SelectedIndex == 0;
                ConfigurationHelper.Save<MyConnection>(conn);
                allowClose = true;
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Make sure connection is ready");
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = txtDatabase.Text.Trim();
            builder.DataSource = txtServer.Text.Trim();
            builder.IntegratedSecurity = comboBox_LoginMode.SelectedIndex == 0;
            builder.UserID = txtUser.Text.Trim();
            builder.Password = txtPassword.Text.Trim();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connection Ready");
                connection_ready = true;
                connection.Close();
            }
            catch (Exception)
            {
                connection_ready = false;
            }

        }

        private void Form_Connection_Load(object sender, EventArgs e)
        {
            ConfigurationHelper.Configuration_FileName = file_name;
            ConfigurationHelper.Key = "12345678";
            if (File.Exists(file_name))
            {
                MyConnection connection = ConfigurationHelper.Read<MyConnection>();
                txtServer.Text = connection.Server;
                txtDatabase.Text = connection.Database;
                txtUser.Text = connection.User;
                txtPassword.Text = connection.Password;
                comboBox_LoginMode.SelectedIndex =Convert.ToInt32( connection.IsWindowsAuthenticationMode);
                comboBox_LoginMode.SelectedIndex = Convert.ToInt32(connection.IsWindowsAuthenticationMode);
            }
            else
            {
                comboBox_LoginMode.SelectedIndex = 0;
            }
        }

        private void ComboBox_LoginMode_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void Form_Connection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                if (MessageBox.Show("Exit application?", "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    allowClose = true;
                    Application.Exit();
                }
            }
        }

        private void ComboBox_LoginMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox_account.Enabled = comboBox_LoginMode.SelectedIndex == 1;
            txtUser.Clear();
            txtPassword.Clear();
        }
    }
}
