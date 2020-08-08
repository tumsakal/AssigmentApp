using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    public class MyConnection
    {
        public MyConnection()
        {
        }
        public string Server { get; set; } = "";
        public string Database { get; set; } = "";
        public string User { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsWindowsAuthenticationMode { get; set; } = true;
        public override string ToString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = Database;
            builder.DataSource = Server;
            builder.IntegratedSecurity = IsWindowsAuthenticationMode;
            builder.UserID = User;
            builder.Password = Password;
            return builder.ConnectionString;
        }
    }

}
