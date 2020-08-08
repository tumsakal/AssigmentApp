using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Assignment
{
    static class Program
    {
        public static string sid, staff_name, user_role;
        public static string file_name = "sokhareaksmey.con";
        public static SqlConnection Connection;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ConfigurationHelper.Configuration_FileName = file_name;
            ConfigurationHelper.Key = "12345678";
            if (!File.Exists(file_name))
            {
                Form_Connection frm_conn = new Form_Connection();
                frm_conn.file_name = file_name;
                Application.Run(frm_conn);
            }
            MyConnection my_connection = ConfigurationHelper.Read<MyConnection>();
            Connection = new SqlConnection(my_connection.ToString());
            Application.Run(new Form_Login());
            
            //Form_Sale frm_sale = new Form_Sale();
            //frm_sale.WindowState = FormWindowState.Maximized;
            //frm_sale.ShowDialog();
        }
    }
}
