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
    public partial class Form_Product : Form
    {
        Form_Product_View frm_view = new Form_Product_View();
        Form_Product_Add frm_add = new Form_Product_Add();
        Form_Product_Update frm_update = new Form_Product_Update();

        public Form_Product()
        {
            InitializeComponent();
            frm_view.TopLevel = false;
            frm_view.Dock = DockStyle.Fill;
            frm_add.TopLevel = false;
            frm_update.TopLevel = false;
            frm_update.Dock = DockStyle.Fill;
            frm_update.frm_pro = this;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            foreach (Form frm in panel_container.Controls)
                frm.Hide();
            //
            if (!panel_container.Controls.ContainsKey("Form_Product_View"))
            {
                panel_container.Controls.Add(frm_view);
                frm_view.Show();
            }
            else
            {
                frm_view.Show();
            }
            frm_view.Form_Product_View_Load(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Form frm in panel_container.Controls)
                frm.Hide();
            frm_add.Location = new Point((panel_container.Width - frm_add.Width) / 2, (panel_container.Height - frm_add.Height) / 2);
            //
            if (!panel_container.Controls.ContainsKey("Form_Product_Add"))
            {
                panel_container.Controls.Add(frm_add);
                frm_add.Show();
            }
            else
            {
                frm_add.Show();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (frm_view.dataGridView1.SelectedRows.Count != 0)
            {
                foreach (Form frm in panel_container.Controls)
                    frm.Hide();
                ////////////////////////////////////////////////////////////////
                frm_update.txtID.Text = frm_view.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm_update.txtBarcode.Text = frm_view.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm_update.txtName.Text = frm_view.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm_update.cboCategory.Text = frm_view.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frm_update.cboSize.Text = frm_view.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //frm_update.dateTimePicker_Exp.Value = (DateTime)frm_view.dataGridView1.CurrentRow.Cells[5].Value;
                frm_update.txtPrice.Text = Convert.ToDouble(frm_view.dataGridView1.CurrentRow.Cells[5].Value).ToString("#,###.00");//10.00//56,234.00
                                                                                                                                   //0,000.00//0,010.00//56,234.00
                frm_update.chkAvailable.Checked = (bool)frm_view.dataGridView1.CurrentRow.Cells[6].Value;
                //
                System.IO.MemoryStream mem = new System.IO.MemoryStream((byte[])frm_view.dataGridView1.CurrentRow.Cells[7].Value);
                frm_update.pictureBox1.Image = Image.FromStream(mem);
                //
                frm_update.txtDescription.Text = frm_view.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                /////////////////////////////////////////////////////////////////

                if (!panel_container.Controls.ContainsKey("Form_Product_Update"))
                {
                    panel_container.Controls.Add(frm_update);
                    frm_update.Show();
                }
                else
                {
                    frm_update.Show();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (frm_view.dataGridView1.SelectedRows.Count != 0)
                if (MessageBox.Show("Do you want to delete?") == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Program.Connection;
                    cmd.CommandText = "delete from tbl_product where PID = @pid;";
                    string id = frm_view.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    cmd.Parameters.AddWithValue("@pid", id);
                    Program.Connection.Open();
                    cmd.ExecuteNonQuery();
                    Program.Connection.Close();
                    btnShow.PerformClick();
                }
            
        }
    }
}
