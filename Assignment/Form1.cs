using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Customer_Main frm = new Form_Customer_Main();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            //
            panel_Container.Controls.Clear();
            panel_Container.Controls.Add(frm);
            //
            frm.Show();
        }

        private void CustomerCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Customer_Discount_Card frm = new Form_Customer_Discount_Card();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            //
            panel_Container.Controls.Clear();
            panel_Container.Controls.Add(frm);
            //
            frm.Show();
        }

        private void AssignCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Assign_Card frm = new Form_Assign_Card();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void ExtendCardExpireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Extend frm = new Form_Extend();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void applicationSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Connection frm_conn = new Form_Connection();
            frm_conn.file_name = Program.file_name;
            frm_conn.ShowDialog();
            MessageBox.Show("Please Restart Application");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Sale frm_sale = new Form_Sale();
            frm_sale.WindowState = FormWindowState.Maximized;
            frm_sale.ShowDialog();
        }

        private void គរបគរងផលតផលToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form_Product frm_pro = new Form_Product();
            frm_pro.TopLevel = false;
            frm_pro.Dock = DockStyle.Fill;
            //
            panel_Container.Controls.Clear();
            panel_Container.Controls.Add(frm_pro);
            //
            frm_pro.Show();
        }

        private void បងកតគណនយសរបបគគលកToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Add_UserAccount frm = new Form_Add_UserAccount();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void បរវតតករលកToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Sale_History frm = new Form_Sale_History();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            //
            panel_Container.Controls.Clear();
            panel_Container.Controls.Add(frm);
            //
            frm.Show();
        }

        private void របយកណបរចខToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Monthly_Report frm = new Form_Monthly_Report();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}
