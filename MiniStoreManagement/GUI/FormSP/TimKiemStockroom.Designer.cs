namespace MiniStoreManagement.GUI.FormSP
{
    partial class TimKiemStockroom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimKiemStockroom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnPrice = new System.Windows.Forms.Button();
            this.ID_product = new System.Windows.Forms.Button();
            this.btnExp = new System.Windows.Forms.Button();
            this.btnQuantity = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbbID_product = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPrice1);
            this.panel1.Controls.Add(this.lbCount);
            this.panel1.Controls.Add(this.btnPrice);
            this.panel1.Controls.Add(this.ID_product);
            this.panel1.Controls.Add(this.btnExp);
            this.panel1.Controls.Add(this.btnQuantity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cbbID_product);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.txtPrice2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 436);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(493, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 32);
            this.label3.TabIndex = 104;
            this.label3.Text = "-";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Location = new System.Drawing.Point(185, 118);
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(210, 40);
            this.txtPrice1.TabIndex = 103;
            this.txtPrice1.Text = "0";
            this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbCount.Location = new System.Drawing.Point(583, 365);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(241, 32);
            this.lbCount.TabIndex = 102;
            this.lbCount.Text = "Tìm được n dòng.";
            // 
            // btnPrice
            // 
            this.btnPrice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrice.BackgroundImage")));
            this.btnPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrice.FlatAppearance.BorderSize = 0;
            this.btnPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrice.Location = new System.Drawing.Point(836, 123);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(37, 31);
            this.btnPrice.TabIndex = 101;
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ID_product
            // 
            this.ID_product.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ID_product.BackgroundImage")));
            this.ID_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ID_product.FlatAppearance.BorderSize = 0;
            this.ID_product.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ID_product.Location = new System.Drawing.Point(408, 46);
            this.ID_product.Name = "ID_product";
            this.ID_product.Size = new System.Drawing.Size(37, 31);
            this.ID_product.TabIndex = 100;
            this.ID_product.UseVisualStyleBackColor = true;
            this.ID_product.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExp
            // 
            this.btnExp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExp.BackgroundImage")));
            this.btnExp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExp.FlatAppearance.BorderSize = 0;
            this.btnExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExp.Location = new System.Drawing.Point(836, 277);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(37, 31);
            this.btnExp.TabIndex = 98;
            this.btnExp.UseVisualStyleBackColor = true;
            this.btnExp.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuantity.BackgroundImage")));
            this.btnQuantity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuantity.FlatAppearance.BorderSize = 0;
            this.btnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuantity.Location = new System.Drawing.Point(836, 200);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.Size = new System.Drawing.Size(37, 31);
            this.btnQuantity.TabIndex = 97;
            this.btnQuantity.UseVisualStyleBackColor = true;
            this.btnQuantity.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(491, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 32);
            this.label6.TabIndex = 96;
            this.label6.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(493, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 32);
            this.label4.TabIndex = 95;
            this.label4.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(154, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 32);
            this.label1.TabIndex = 94;
            this.label1.Text = ":";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(614, 195);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(210, 40);
            this.numericUpDown2.TabIndex = 93;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = " ";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(614, 272);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(210, 40);
            this.dateTimePicker2.TabIndex = 92;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(183, 195);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(210, 40);
            this.numericUpDown1.TabIndex = 91;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(156, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 32);
            this.label18.TabIndex = 90;
            this.label18.Text = ":";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(156, 276);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 32);
            this.label16.TabIndex = 88;
            this.label16.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(157, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 32);
            this.label13.TabIndex = 85;
            this.label13.Text = ":";
            // 
            // cbbID_product
            // 
            this.cbbID_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbID_product.FormattingEnabled = true;
            this.cbbID_product.Location = new System.Drawing.Point(185, 41);
            this.cbbID_product.Name = "cbbID_product";
            this.cbbID_product.Size = new System.Drawing.Size(210, 40);
            this.cbbID_product.TabIndex = 83;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = " ";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(185, 272);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 40);
            this.dateTimePicker1.TabIndex = 82;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // txtPrice2
            // 
            this.txtPrice2.Location = new System.Drawing.Point(616, 118);
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(210, 40);
            this.txtPrice2.TabIndex = 79;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(27, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 32);
            this.label11.TabIndex = 77;
            this.label11.Text = "Giá tiền";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(27, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 32);
            this.label10.TabIndex = 76;
            this.label10.Text = "Số lượng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(27, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 32);
            this.label9.TabIndex = 75;
            this.label9.Text = "ID_SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(27, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 32);
            this.label2.TabIndex = 72;
            this.label2.Text = "HSD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 354);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 55);
            this.button1.TabIndex = 38;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimKiemStockroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 436);
            this.Controls.Add(this.panel1);
            this.Name = "TimKiemStockroom";
            this.Text = "TimKiemStockroom";
            this.Load += new System.EventHandler(this.TimKiemStockroom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button btnPrice;
        private System.Windows.Forms.Button ID_product;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.Button btnQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbID_product;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtPrice2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice1;
    }
}