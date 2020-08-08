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
    public partial class Form_Customer_Main : Form
    {
        public SqlDataAdapter adapter;
        public DataSet ds = new DataSet();

        public Form_Customer_Main()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            MyConnection myConnection = ConfigurationHelper.Read<MyConnection>();
            string connection_string = myConnection.ToString();
            string sql_select = "select * from tbl_Customer;";
            adapter = new SqlDataAdapter(sql_select, connection_string);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            //
            if (ds.Tables.Contains("Customer") == true)
                ds.Tables["Customer"].Clear();
            adapter.Fill(ds, "Customer");
            //
            ds.Tables["Customer"].Columns[0].AutoIncrement = true;
            ds.Tables["Customer"].Columns[0].AutoIncrementStep = 1;
            int auto_id = 0;
            if (ds.Tables["Customer"].Rows.Count > 0)
                auto_id = (int)ds.Tables["Customer"].Compute("MAX(CID)", "") + 1;
            ds.Tables["Customer"].Columns[0].AutoIncrementSeed = auto_id;
            //
            dataGridView1.DataSource = ds.Tables["Customer"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_Customer_Add frm_add = new Form_Customer_Add();
            frm_add.StartPosition = FormStartPosition.CenterParent;
            frm_add.frm_main = this;
            frm_add.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                Form_Customer_Update frm_update = new Form_Customer_Update();
                frm_update.id = id;
                frm_update.frm_main = this;
                frm_update.ShowDialog();
            }
        }

        private void Form_Customer_Main_Load(object sender, EventArgs e)
        {
            btnLoad.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you want to delete?") == DialogResult.OK)
                {
                    int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    ds.Tables["Customer"].Select("CID=" + id).First().Delete();
                    adapter.Update(ds.Tables["Customer"]);
                    MessageBox.Show("Deleted");
                }
            }
        }
    }
}
