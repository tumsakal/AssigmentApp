namespace Assignment
{
    partial class Form_Sale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Sale));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave_and_Print = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Payment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Total_Price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Total_Qty = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblStaff = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Product = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel_Category = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cboCustomer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1250, 50);
            this.panel2.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(823, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 31);
            this.label13.TabIndex = 4;
            this.label13.Text = "Tel:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(194, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 31);
            this.label12.TabIndex = 3;
            this.label12.Text = "Address:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.White;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(12, 12);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(176, 39);
            this.cboCustomer.TabIndex = 0;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblInvoiceID);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnSave_and_Print);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_Payment);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtDiscount);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_Total_Price);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_Total_Qty);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(826, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 518);
            this.panel3.TabIndex = 2;
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.BackColor = System.Drawing.Color.White;
            this.lblInvoiceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInvoiceID.Location = new System.Drawing.Point(93, 6);
            this.lblInvoiceID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(327, 25);
            this.lblInvoiceID.TabIndex = 7;
            this.lblInvoiceID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "លេខវិក័យប័ត្រ";
            // 
            // btnSave_and_Print
            // 
            this.btnSave_and_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave_and_Print.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave_and_Print.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnSave_and_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave_and_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave_and_Print.ForeColor = System.Drawing.Color.White;
            this.btnSave_and_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave_and_Print.ImageKey = "Print_40px.png";
            this.btnSave_and_Print.ImageList = this.imageList1;
            this.btnSave_and_Print.Location = new System.Drawing.Point(18, 475);
            this.btnSave_and_Print.Name = "btnSave_and_Print";
            this.btnSave_and_Print.Size = new System.Drawing.Size(393, 37);
            this.btnSave_and_Print.TabIndex = 14;
            this.btnSave_and_Print.Text = "រក្សាទុក និង បោះពុម្ព";
            this.btnSave_and_Print.UseVisualStyleBackColor = false;
            this.btnSave_and_Print.Click += new System.EventHandler(this.btnSave_and_Print_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Print_40px.png");
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 31);
            this.label10.TabIndex = 13;
            this.label10.Text = "អាប់";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox5.BackColor = System.Drawing.Color.SeaGreen;
            this.textBox5.Location = new System.Drawing.Point(289, 370);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(122, 38);
            this.textBox5.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(246, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 31);
            this.label11.TabIndex = 11;
            this.label11.Text = "ទទួល";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox6.BackColor = System.Drawing.Color.SeaGreen;
            this.textBox6.Location = new System.Drawing.Point(289, 341);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(122, 38);
            this.textBox6.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 434);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 31);
            this.label9.TabIndex = 9;
            this.label9.Text = "តំលៃសរុប";
            // 
            // txt_Payment
            // 
            this.txt_Payment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Payment.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_Payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Payment.ForeColor = System.Drawing.Color.White;
            this.txt_Payment.Location = new System.Drawing.Point(84, 431);
            this.txt_Payment.Name = "txt_Payment";
            this.txt_Payment.Size = new System.Drawing.Size(132, 38);
            this.txt_Payment.TabIndex = 8;
            this.txt_Payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "បញ្ចុះតំលៃ";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiscount.BackColor = System.Drawing.Color.SeaGreen;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.White;
            this.txtDiscount.Location = new System.Drawing.Point(84, 402);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(132, 38);
            this.txtDiscount.TabIndex = 6;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(249, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "គិតលុយ";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "តំលៃ";
            // 
            // txt_Total_Price
            // 
            this.txt_Total_Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Total_Price.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_Total_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total_Price.ForeColor = System.Drawing.Color.White;
            this.txt_Total_Price.Location = new System.Drawing.Point(84, 373);
            this.txt_Total_Price.Name = "txt_Total_Price";
            this.txt_Total_Price.Size = new System.Drawing.Size(132, 38);
            this.txt_Total_Price.TabIndex = 3;
            this.txt_Total_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "ចំនូនសរុប";
            // 
            // txt_Total_Qty
            // 
            this.txt_Total_Qty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Total_Qty.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_Total_Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total_Qty.ForeColor = System.Drawing.Color.White;
            this.txt_Total_Qty.Location = new System.Drawing.Point(84, 344);
            this.txt_Total_Qty.Name = "txt_Total_Qty";
            this.txt_Total_Qty.Size = new System.Drawing.Size(132, 38);
            this.txt_Total_Qty.TabIndex = 1;
            this.txt_Total_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(418, 289);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(421, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "​​​​​​​​4100";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(194, 540);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 37);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 31);
            this.label8.TabIndex = 6;
            this.label8.Text = "អត្រាប្តូរប្រាក់";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.BackColor = System.Drawing.Color.SeaGreen;
            this.panel7.Controls.Add(this.lblStaff);
            this.panel7.Location = new System.Drawing.Point(0, 540);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(188, 37);
            this.panel7.TabIndex = 8;
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.Color.White;
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.Location = new System.Drawing.Point(13, 6);
            this.lblStaff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(164, 25);
            this.lblStaff.TabIndex = 6;
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel_Product
            // 
            this.flowLayoutPanel_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_Product.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel_Product.Location = new System.Drawing.Point(194, 59);
            this.flowLayoutPanel_Product.Name = "flowLayoutPanel_Product";
            this.flowLayoutPanel_Product.Size = new System.Drawing.Size(626, 475);
            this.flowLayoutPanel_Product.TabIndex = 9;
            // 
            // flowLayoutPanel_Category
            // 
            this.flowLayoutPanel_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel_Category.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel_Category.Location = new System.Drawing.Point(0, 59);
            this.flowLayoutPanel_Category.Name = "flowLayoutPanel_Category";
            this.flowLayoutPanel_Category.Size = new System.Drawing.Size(188, 475);
            this.flowLayoutPanel_Category.TabIndex = 10;
            // 
            // Form_Sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1250, 589);
            this.Controls.Add(this.flowLayoutPanel_Category);
            this.Controls.Add(this.flowLayoutPanel_Product);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Sale";
            this.Text = "Form_Sale";
            this.Load += new System.EventHandler(this.Form_Sale_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Total_Price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Total_Qty;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Product;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Category;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btnSave_and_Print;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
    }
}