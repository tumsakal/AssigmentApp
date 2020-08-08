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
    public partial class Form_Product_Update : Form
    {
        public Form_Product frm_pro;
        public Form_Product_Update()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MyConnection myConnection = ConfigurationHelper.Read<MyConnection>();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = myConnection.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE tbl_product set Barcode = @barcode, PName = @pname, Category = @cate, SizeType = @size, ExpireDate = @exp, Price = @price, Available = @available, Image = @image, Description = @desc where PID = @pid;";
                cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());
                cmd.Parameters.AddWithValue("@pname", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@cate", cboCategory.Text);
                cmd.Parameters.AddWithValue("@size", cboSize.Text);
                cmd.Parameters.AddWithValue("@exp", dateTimePicker_Exp.Value);
                cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text.Trim()));

                //
                System.IO.MemoryStream mem = new System.IO.MemoryStream();
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Save(mem, pictureBox1.Image.RawFormat);
                else
                    pictureBox1.ErrorImage.Save(mem, pictureBox1.ErrorImage.RawFormat);
                cmd.Parameters.AddWithValue("@image", mem.ToArray());
                //
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@pid", txtID.Text);
                cmd.Parameters.AddWithValue("@available", chkAvailable.Checked);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                frm_pro.btnShow.PerformClick();//
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Clear
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox) (ctr as TextBox).Clear();
                else if (ctr is ComboBox) (ctr as ComboBox).Text = "";
                else if (ctr is DateTimePicker) (ctr as DateTimePicker).Value = DateTime.Now;
                else if (ctr is PictureBox) (ctr as PictureBox).Image = null;
            }
        }
    }
}
