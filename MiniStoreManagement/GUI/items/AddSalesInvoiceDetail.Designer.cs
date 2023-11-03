namespace MiniStoreManagement.GUI.items
{
    partial class AddSalesInvoiceDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cbbID_invoice = new System.Windows.Forms.ComboBox();
            this.cbbID_product = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.cbbID_invoice);
            this.panel1.Controls.Add(this.cbbID_product);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 14F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 199);
            this.panel1.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(640, 34);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(214, 40);
            this.numericUpDown1.TabIndex = 34;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(640, 116);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(214, 40);
            this.txtPrice.TabIndex = 9;
            // 
            // cbbID_invoice
            // 
            this.cbbID_invoice.Enabled = false;
            this.cbbID_invoice.FormattingEnabled = true;
            this.cbbID_invoice.Location = new System.Drawing.Point(216, 34);
            this.cbbID_invoice.Name = "cbbID_invoice";
            this.cbbID_invoice.Size = new System.Drawing.Size(214, 40);
            this.cbbID_invoice.TabIndex = 50;
            // 
            // cbbID_product
            // 
            this.cbbID_product.FormattingEnabled = true;
            this.cbbID_product.Location = new System.Drawing.Point(216, 116);
            this.cbbID_product.Name = "cbbID_product";
            this.cbbID_product.Size = new System.Drawing.Size(214, 40);
            this.cbbID_product.TabIndex = 49;
            this.cbbID_product.SelectedIndexChanged += new System.EventHandler(this.cbbID_product_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(601, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 32);
            this.label12.TabIndex = 48;
            this.label12.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(601, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 32);
            this.label15.TabIndex = 45;
            this.label15.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(460, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 32);
            this.label11.TabIndex = 44;
            this.label11.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(460, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 32);
            this.label3.TabIndex = 43;
            this.label3.Text = "Thành tiền";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(188, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 32);
            this.label10.TabIndex = 37;
            this.label10.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(188, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 32);
            this.label7.TabIndex = 34;
            this.label7.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(20, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID hóa đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(20, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID sản phẩm";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.BtnPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Arial", 14F);
            this.panel2.Location = new System.Drawing.Point(0, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 616);
            this.panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(828, 394);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(1004, 181);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(114, 66);
            this.BtnPrint.TabIndex = 32;
            this.BtnPrint.Text = "In";
            this.BtnPrint.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 492);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(146, 68);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(189, 492);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(146, 68);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(364, 492);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(146, 68);
            this.btnDel.TabIndex = 35;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(539, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 68);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(714, 492);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(146, 68);
            this.btnNew.TabIndex = 37;
            this.btnNew.Text = "Mới";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // AddSalesInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddSalesInvoiceDetail";
            this.Size = new System.Drawing.Size(874, 815);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cbbID_invoice;
        private System.Windows.Forms.ComboBox cbbID_product;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
    }
}
