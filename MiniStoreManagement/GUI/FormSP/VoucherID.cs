using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.FormSP
{
    public partial class VoucherID : Form
    {
        VoucherBUS voucherBUS = new VoucherBUS();
        public delegate void truyenDuLieu(string txt);
        public truyenDuLieu temp;
        public VoucherID()
        {
            InitializeComponent();
        }

        private void VoucherID_Load(object sender, EventArgs e)
        {
            if (VoucherBUS.VoucherList == null)
                voucherBUS.getVoucher();

            foreach (DataRow row in VoucherBUS.VoucherList.Rows)
            {
                cbbID_voucher1.Items.Add(row["ID"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbbID_voucher1.SelectedItem != null)
                temp(cbbID_voucher1.SelectedItem.ToString());
            else
                temp(null);
            this.Close();
        }
    }
}
