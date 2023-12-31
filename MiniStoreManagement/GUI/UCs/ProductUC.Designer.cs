﻿namespace MiniStoreManagement.GUI.UCs
{
    partial class ProductUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductUC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbID_provider = new System.Windows.Forms.ComboBox();
            this.cbbID_category = new System.Windows.Forms.ComboBox();
            this.cbbID_promotion = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.btnReset_KM = new System.Windows.Forms.Button();
            this.btnReset_DM = new System.Windows.Forms.Button();
            this.btnReset_IMG = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(93)))), ((int)(((byte)(123)))));
            this.panel1.Controls.Add(this.btnReset_IMG);
            this.panel1.Controls.Add(this.btnReset_DM);
            this.panel1.Controls.Add(this.btnReset_KM);
            this.panel1.Controls.Add(this.lbPrice);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cbbID_provider);
            this.panel1.Controls.Add(this.cbbID_category);
            this.panel1.Controls.Add(this.cbbID_promotion);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 14F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 378);
            this.panel1.TabIndex = 1;
            // 
            // lbPrice
            // 
            this.lbPrice.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbPrice.Location = new System.Drawing.Point(614, 226);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(210, 40);
            this.lbPrice.TabIndex = 69;
            this.lbPrice.Text = "500,000";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbPrice.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(672, 304);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 51);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.Text = "search +";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnsearch_click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(616, 99);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(210, 40);
            this.numericUpDown1.TabIndex = 67;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(164, 173);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 32);
            this.label18.TabIndex = 66;
            this.label18.Text = ":";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label17.Location = new System.Drawing.Point(164, 243);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 32);
            this.label17.TabIndex = 65;
            this.label17.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(164, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 32);
            this.label15.TabIndex = 63;
            this.label15.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(588, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 32);
            this.label14.TabIndex = 62;
            this.label14.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(588, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 32);
            this.label13.TabIndex = 61;
            this.label13.Text = ":";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(588, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 32);
            this.label12.TabIndex = 60;
            this.label12.Text = ":";
            // 
            // cbbID_provider
            // 
            this.cbbID_provider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbID_provider.FormattingEnabled = true;
            this.cbbID_provider.Location = new System.Drawing.Point(192, 169);
            this.cbbID_provider.Name = "cbbID_provider";
            this.cbbID_provider.Size = new System.Drawing.Size(210, 40);
            this.cbbID_provider.TabIndex = 59;
            // 
            // cbbID_category
            // 
            this.cbbID_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbID_category.FormattingEnabled = true;
            this.cbbID_category.Location = new System.Drawing.Point(192, 239);
            this.cbbID_category.Name = "cbbID_category";
            this.cbbID_category.Size = new System.Drawing.Size(210, 40);
            this.cbbID_category.TabIndex = 57;
            // 
            // cbbID_promotion
            // 
            this.cbbID_promotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbID_promotion.FormattingEnabled = true;
            this.cbbID_promotion.Location = new System.Drawing.Point(192, 99);
            this.cbbID_promotion.Name = "cbbID_promotion";
            this.cbbID_promotion.Size = new System.Drawing.Size(210, 40);
            this.cbbID_promotion.TabIndex = 54;
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(616, 169);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(210, 40);
            this.txtPrice.TabIndex = 52;
            this.txtPrice.Text = "0";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(616, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 40);
            this.txtName.TabIndex = 48;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(453, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 32);
            this.label11.TabIndex = 46;
            this.label11.Text = "Giá tiền";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(453, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 32);
            this.label10.TabIndex = 45;
            this.label10.Text = "Số lượng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(29, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 32);
            this.label9.TabIndex = 44;
            this.label9.Text = "ID_NC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(29, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 32);
            this.label5.TabIndex = 43;
            this.label5.Text = "ID_KM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(29, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 32);
            this.label3.TabIndex = 42;
            this.label3.Text = "ID_DM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(453, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 32);
            this.label1.TabIndex = 40;
            this.label1.Text = "Tên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(164, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 32);
            this.label8.TabIndex = 35;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(164, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 32);
            this.label7.TabIndex = 34;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(29, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 32);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(192, 309);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(412, 40);
            this.txtSearch.TabIndex = 32;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(192, 29);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(210, 40);
            this.txtID.TabIndex = 9;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(927, 304);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(152, 51);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MiniStoreManagement.Properties.Resources.vòng_tròn;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(871, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 247);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(29, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(93)))), ((int)(((byte)(123)))));
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.BtnUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Arial", 14F);
            this.panel2.Location = new System.Drawing.Point(0, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 437);
            this.panel2.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(1004, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(114, 66);
            this.btnNew.TabIndex = 35;
            this.btnNew.Text = "mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(942, 394);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(1004, 240);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(114, 66);
            this.btnDel.TabIndex = 34;
            this.btnDel.Text = "xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1004, 131);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 66);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(1004, 349);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(114, 66);
            this.BtnUpdate.TabIndex = 32;
            this.BtnUpdate.Text = "sửa";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnReset_KM
            // 
            this.btnReset_KM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset_KM.BackgroundImage")));
            this.btnReset_KM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset_KM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset_KM.FlatAppearance.BorderSize = 0;
            this.btnReset_KM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset_KM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset_KM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset_KM.Location = new System.Drawing.Point(408, 104);
            this.btnReset_KM.Name = "btnReset_KM";
            this.btnReset_KM.Size = new System.Drawing.Size(37, 31);
            this.btnReset_KM.TabIndex = 100;
            this.btnReset_KM.UseVisualStyleBackColor = true;
            this.btnReset_KM.Click += new System.EventHandler(this.btnReset_KM_Click);
            // 
            // btnReset_DM
            // 
            this.btnReset_DM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset_DM.BackgroundImage")));
            this.btnReset_DM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset_DM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset_DM.FlatAppearance.BorderSize = 0;
            this.btnReset_DM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset_DM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset_DM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset_DM.Location = new System.Drawing.Point(408, 243);
            this.btnReset_DM.Name = "btnReset_DM";
            this.btnReset_DM.Size = new System.Drawing.Size(37, 31);
            this.btnReset_DM.TabIndex = 101;
            this.btnReset_DM.UseVisualStyleBackColor = true;
            this.btnReset_DM.Click += new System.EventHandler(this.btnReset_DM_Click);
            // 
            // btnReset_IMG
            // 
            this.btnReset_IMG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset_IMG.BackgroundImage")));
            this.btnReset_IMG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset_IMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset_IMG.FlatAppearance.BorderSize = 0;
            this.btnReset_IMG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReset_IMG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReset_IMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset_IMG.Location = new System.Drawing.Point(1085, 314);
            this.btnReset_IMG.Name = "btnReset_IMG";
            this.btnReset_IMG.Size = new System.Drawing.Size(37, 31);
            this.btnReset_IMG.TabIndex = 102;
            this.btnReset_IMG.UseVisualStyleBackColor = true;
            this.btnReset_IMG.Click += new System.EventHandler(this.btnReset_IMG_Click);
            // 
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(1148, 815);
            this.Load += new System.EventHandler(this.ProductUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.ComboBox cbbID_category;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbID_provider;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox cbbID_promotion;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Button btnReset_DM;
        private System.Windows.Forms.Button btnReset_KM;
        private System.Windows.Forms.Button btnReset_IMG;
    }
}
