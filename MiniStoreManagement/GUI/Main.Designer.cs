namespace MiniStoreManagement.GUI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.picBin = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSlideMenu = new System.Windows.Forms.Panel();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnProvider = new System.Windows.Forms.Button();
            this.btnPromotion = new System.Windows.Forms.Button();
            this.btnVoucher = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnsub_invoice1 = new System.Windows.Forms.Button();
            this.btnsub_invoice2 = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnConsumer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).BeginInit();
            this.panelSlideMenu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.picBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1489, 112);
            this.panel1.TabIndex = 0;
            // 
            // picBack
            // 
            this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(12, 18);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(92, 76);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 2;
            this.picBack.TabStop = false;
            this.picBack.Visible = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // picBin
            // 
            this.picBin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBin.Image = ((System.Drawing.Image)(resources.GetObject("picBin.Image")));
            this.picBin.Location = new System.Drawing.Point(13, 18);
            this.picBin.Name = "picBin";
            this.picBin.Size = new System.Drawing.Size(92, 76);
            this.picBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBin.TabIndex = 1;
            this.picBin.TabStop = false;
            this.picBin.Visible = false;
            this.picBin.Click += new System.EventHandler(this.picBin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(507, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Managerment App";
            // 
            // panelSlideMenu
            // 
            this.panelSlideMenu.AutoScroll = true;
            this.panelSlideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.panelSlideMenu.Controls.Add(this.btnCategory);
            this.panelSlideMenu.Controls.Add(this.btnEmployee);
            this.panelSlideMenu.Controls.Add(this.btnProvider);
            this.panelSlideMenu.Controls.Add(this.btnPromotion);
            this.panelSlideMenu.Controls.Add(this.btnVoucher);
            this.panelSlideMenu.Controls.Add(this.panel5);
            this.panelSlideMenu.Controls.Add(this.btnInvoice);
            this.panelSlideMenu.Controls.Add(this.btnConsumer);
            this.panelSlideMenu.Controls.Add(this.panel2);
            this.panelSlideMenu.Controls.Add(this.btnProduct);
            this.panelSlideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlideMenu.Location = new System.Drawing.Point(0, 112);
            this.panelSlideMenu.Name = "panelSlideMenu";
            this.panelSlideMenu.Size = new System.Drawing.Size(341, 815);
            this.panelSlideMenu.TabIndex = 1;
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnCategory.Location = new System.Drawing.Point(0, 719);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(341, 77);
            this.btnCategory.TabIndex = 23;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnEmployee.Location = new System.Drawing.Point(0, 642);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(341, 77);
            this.btnEmployee.TabIndex = 22;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnProvider
            // 
            this.btnProvider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnProvider.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProvider.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProvider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnProvider.Location = new System.Drawing.Point(0, 565);
            this.btnProvider.Name = "btnProvider";
            this.btnProvider.Size = new System.Drawing.Size(341, 77);
            this.btnProvider.TabIndex = 21;
            this.btnProvider.Text = "Provider";
            this.btnProvider.UseVisualStyleBackColor = false;
            this.btnProvider.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnPromotion
            // 
            this.btnPromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnPromotion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPromotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromotion.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromotion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnPromotion.Location = new System.Drawing.Point(0, 488);
            this.btnPromotion.Name = "btnPromotion";
            this.btnPromotion.Size = new System.Drawing.Size(341, 77);
            this.btnPromotion.TabIndex = 20;
            this.btnPromotion.Text = "Promotion";
            this.btnPromotion.UseVisualStyleBackColor = false;
            this.btnPromotion.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnVoucher
            // 
            this.btnVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnVoucher.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucher.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnVoucher.Location = new System.Drawing.Point(0, 411);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Size = new System.Drawing.Size(341, 77);
            this.btnVoucher.TabIndex = 19;
            this.btnVoucher.Text = "Voucher";
            this.btnVoucher.UseVisualStyleBackColor = false;
            this.btnVoucher.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnsub_invoice1);
            this.panel5.Controls.Add(this.btnsub_invoice2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 291);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(341, 120);
            this.panel5.TabIndex = 18;
            // 
            // btnsub_invoice1
            // 
            this.btnsub_invoice1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnsub_invoice1.Location = new System.Drawing.Point(0, 0);
            this.btnsub_invoice1.Name = "btnsub_invoice1";
            this.btnsub_invoice1.Size = new System.Drawing.Size(341, 60);
            this.btnsub_invoice1.TabIndex = 2;
            this.btnsub_invoice1.Text = "Invoice";
            this.btnsub_invoice1.UseVisualStyleBackColor = true;
            this.btnsub_invoice1.Click += new System.EventHandler(this.SubButton_Click);
            // 
            // btnsub_invoice2
            // 
            this.btnsub_invoice2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnsub_invoice2.Location = new System.Drawing.Point(0, 60);
            this.btnsub_invoice2.Name = "btnsub_invoice2";
            this.btnsub_invoice2.Size = new System.Drawing.Size(341, 60);
            this.btnsub_invoice2.TabIndex = 1;
            this.btnsub_invoice2.Text = "Invoice detail";
            this.btnsub_invoice2.UseVisualStyleBackColor = true;
            this.btnsub_invoice2.Click += new System.EventHandler(this.SubButton_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoice.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnInvoice.Location = new System.Drawing.Point(0, 214);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(341, 77);
            this.btnInvoice.TabIndex = 14;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnConsumer
            // 
            this.btnConsumer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnConsumer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsumer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumer.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnConsumer.Location = new System.Drawing.Point(0, 137);
            this.btnConsumer.Name = "btnConsumer";
            this.btnConsumer.Size = new System.Drawing.Size(341, 77);
            this.btnConsumer.TabIndex = 13;
            this.btnConsumer.Text = "Consumer";
            this.btnConsumer.UseVisualStyleBackColor = false;
            this.btnConsumer.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 60);
            this.panel2.TabIndex = 12;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button7.Font = new System.Drawing.Font("MV Boli", 16F);
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(341, 60);
            this.button7.TabIndex = 2;
            this.button7.Text = "(+)";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(112)))));
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(254)))), ((int)(((byte)(250)))));
            this.btnProduct.Location = new System.Drawing.Point(0, 0);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(341, 77);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(341, 112);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1148, 815);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picBin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1371, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(118, 112);
            this.panel3.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 927);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelSlideMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBin)).EndInit();
            this.panelSlideMenu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSlideMenu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnPromotion;
        private System.Windows.Forms.Button btnVoucher;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnConsumer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProvider;
        private System.Windows.Forms.Button btnsub_invoice2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnsub_invoice1;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.PictureBox picBin;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Panel panel3;
    }
}