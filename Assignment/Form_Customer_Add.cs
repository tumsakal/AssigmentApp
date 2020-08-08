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
    public partial class Form_Customer_Add : Form
    {
        public Form_Customer_Main frm_main;
        public Form_Customer_Add()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow new_row = frm_main.ds.Tables["Customer"].NewRow();
            //
            new_row[1] = txtName.Text.Trim();
            new_row[2] = cboGender.Text;
            new_row[3] = txtPOB.Text.Trim();
            new_row[4] = txtAddress.Text.Trim();
            new_row[5] = dateTimePicker_DOB.Value;
            new_row[6] = txtPhone.Text.Trim();
            new_row[7] = txtEmail.Text.Trim();
            new_row[8] = cboType.Text;
            new_row[9] = dateTimePicker_Register.Value;
            //
            frm_main.ds.Tables["Customer"].Rows.Add(new_row);
            //
            frm_main.adapter.Update(frm_main.ds.Tables["Customer"]);
            this.Close();
        }

        private void Form_Customer_Add_Load(object sender, EventArgs e)
        {

            int auto_id = 0;
            if (frm_main.ds.Tables["Customer"].Rows.Count > 0)
                auto_id = (int)frm_main.ds.Tables["Customer"].Compute("MAX(CID)", "") + 1;
            txtID.Text = auto_id.ToString();
        }
    }
}
