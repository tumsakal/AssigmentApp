using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Assignment
{
    public partial class Form_Monthly_Report : Form
    {
        public Form_Monthly_Report()
        {
            InitializeComponent();
        }

        private void Form_Monthly_Report_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tbl_InvoiceTableAdapter.Fill(DataSet2.tbl_Invoice, int.Parse(Program.sid),
                dateTimePicker_From.Value, dateTimePicker_To.Value
                );
            reportViewer1.LocalReport.SetParameters(new ReportParameter("rp_staffid", Program.sid.ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("rp_staffname", Program.staff_name));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("rp_from", dateTimePicker_From.Value.ToShortDateString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("rp_to", dateTimePicker_To.Value.ToShortDateString()));
            reportViewer1.RefreshReport();
        }

        private void dateTimePicker_To_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
