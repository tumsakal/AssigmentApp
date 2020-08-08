namespace Assignment
{
    partial class UserControl_Product
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Product_Picture = new System.Windows.Forms.Button();
            this.Product_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Product_Picture
            // 
            this.Product_Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Product_Picture.FlatAppearance.BorderSize = 0;
            this.Product_Picture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Product_Picture.Location = new System.Drawing.Point(0, 0);
            this.Product_Picture.Name = "Product_Picture";
            this.Product_Picture.Size = new System.Drawing.Size(200, 200);
            this.Product_Picture.TabIndex = 0;
            this.Product_Picture.UseVisualStyleBackColor = true;
            // 
            // Product_Name
            // 
            this.Product_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Product_Name.BackColor = System.Drawing.Color.SeaGreen;
            this.Product_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product_Name.ForeColor = System.Drawing.Color.White;
            this.Product_Name.Location = new System.Drawing.Point(3, 175);
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.Size = new System.Drawing.Size(194, 25);
            this.Product_Name.TabIndex = 1;
            this.Product_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Product_Name);
            this.Controls.Add(this.Product_Picture);
            this.Name = "UserControl_Product";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Product_Picture;
        public System.Windows.Forms.Label Product_Name;
    }
}
