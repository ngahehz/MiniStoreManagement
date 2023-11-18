namespace MiniStoreManagement.GUI.FormSP
{
    partial class VoucherID
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
            this.cbbID_voucher1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbID_voucher1
            // 
            this.cbbID_voucher1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbID_voucher1.Enabled = false;
            this.cbbID_voucher1.Font = new System.Drawing.Font("Arial", 14F);
            this.cbbID_voucher1.FormattingEnabled = true;
            this.cbbID_voucher1.Location = new System.Drawing.Point(109, 67);
            this.cbbID_voucher1.Name = "cbbID_voucher1";
            this.cbbID_voucher1.Size = new System.Drawing.Size(214, 40);
            this.cbbID_voucher1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.Location = new System.Drawing.Point(94, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 53;
            this.label1.Text = "Chọn mã giảm giá :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 14F);
            this.button1.Location = new System.Drawing.Point(171, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 46);
            this.button1.TabIndex = 54;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VoucherID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbID_voucher1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VoucherID";
            this.Text = "VoucherID";
            this.Load += new System.EventHandler(this.VoucherID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbID_voucher1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}