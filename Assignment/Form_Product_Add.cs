using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace Assignment
{
    public partial class Form_Product_Add : Form
    {
        public Form_Product_Add()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MyConnection myConnection = ConfigurationHelper.Read<MyConnection>();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = myConnection.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into tbl_Product(Barcode, Pname, Category, SizeType, Price, Available, Image, Description) values( @barcode, @pname, @cate, @size, @price, @available, @image, @desc);";
                //
                cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());
                cmd.Parameters.AddWithValue("@pname", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@cate", cboCategory.Text);
                cmd.Parameters.AddWithValue("@size", cboSize.Text);
                cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text.Trim()));
                cmd.Parameters.AddWithValue("@available", chkAvailable.Checked);
                //image
                MemoryStream mem = new MemoryStream();
                pictureBox1.Image.Save(mem, pictureBox1.Image.RawFormat);
                //cmd.Parameters.AddWithValue("@image", mem.ToArray());
                //
                SqlParameter param_image = new SqlParameter();
                param_image.ParameterName = "@image";
                param_image.SqlDbType = SqlDbType.VarBinary;
                param_image.SqlValue = mem.ToArray();
                cmd.Parameters.Add(param_image);

                //
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                //
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is TextBox) (ctr as TextBox).Clear();
                    else if (ctr is ComboBox) (ctr as ComboBox).Text = "";
                    else if (ctr is PictureBox) (ctr as PictureBox).Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DataSet ds = new DataSet();
        private void Form_Product_Add_Load(object sender, EventArgs e)
        {
            string str = "select CategoryName from tbl_Category; select SizeType from tbl_Size;";
            SqlDataAdapter adapter = new SqlDataAdapter(str, Program.Connection);
            adapter.Fill(ds);
            cboCategory.DataSource = ds.Tables[0];
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryName";
            cboSize.DataSource = ds.Tables[1];
            cboSize.DisplayMember = "SizeType";
            cboSize.ValueMember = "SizeType";
        }
    }
}
