using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class VoucherUC : UserControl
    {
        private VoucherBUS voucherBUS = new VoucherBUS();
        private string fileName;
        private bool id_focus = false;
        public VoucherUC()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void VoucherUC_Load(object sender, EventArgs e)
        {
            if (VoucherBUS.VoucherList == null)
                voucherBUS.getVoucher();
            new_id();

            dataGridView1.DataSource = VoucherBUS.VoucherList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "CODE";
            dataGridView1.Columns[2].HeaderText = "DISCRIPTION";
            dataGridView1.Columns[3].HeaderText = "DISCOUNT_AMOUNT";
            dataGridView1.Columns[4].HeaderText = "MIN_INVOICE_VALUE";
            dataGridView1.Columns[5].HeaderText = "PERCENT_DISCOUNT";
            dataGridView1.Columns[6].HeaderText = "MAX_DISCOUNT";
            dataGridView1.Columns[7].HeaderText = "START_DATE";
            dataGridView1.Columns[8].HeaderText = "END_DATE";

        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (id_focus)
            {
                MessageBox.Show("Ấn nút mới để tạo mới form");
                return;
            }
            if (!check())
                return;

            VoucherDTO voucherDTO = new VoucherDTO();
            voucherDTO.Id = int.Parse(txtID.Text);
            voucherDTO.Code = txtCode.Text;
            voucherDTO.Discription = txtDescription.Text;
            voucherDTO.DiscountAmount = decimal.Parse(txtGiagiam.Text);
            voucherDTO.MinInvoiceValue = decimal.Parse(txtGTTT.Text);
            //voucherDTO.PercentDiscount = decimal.Parse(txtChietkhau.Text);
            //voucherDTO.MaxDiscount = decimal.Parse(txtGTTĐ.Text);
            voucherDTO.StartDate = dateTimePicker1.Value;
            voucherDTO.EndDate = dateTimePicker2.Value;

            if (voucherBUS.addVoucher(voucherDTO))
            {
                VoucherBUS.VoucherList.Rows.Add(voucherDTO.Id, voucherDTO.Code, voucherDTO.Discription, voucherDTO.DiscountAmount, voucherDTO.MinInvoiceValue, voucherDTO.MinInvoiceValue, voucherDTO.PercentDiscount, voucherDTO.MaxDiscount, voucherDTO.StartDate, voucherDTO.EndDate);
                dataGridView1.DataSource = VoucherBUS.VoucherList;
                id_focus = true;
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
        }

        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Không được để trống mô tả");
                txtDescription.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiagiam.Text, out decimal number1))
            {
                MessageBox.Show("/nhập lại");
                return false;
            }

            if (!decimal.TryParse(txtGTTT.Text, out decimal number2))
            {
                MessageBox.Show("/nhập lại");
                return false;
            }

            //if (!decimal.TryParse(txtGTTĐ.Text, out decimal number3))
            //{
            //    MessageBox.Show("/nhập lại");
            //    return false;
            //}


            //if (!double.TryParse(txtChietkhau.Text, out double number) || number <= 0 || number >= 1)
            //{
            //    MessageBox.Show("Chiếu khấu phải lại một số thập phân trong khoảng 0 đến 1");
            //    return false;
            //}

            if (dateTimePicker1.CustomFormat == " ")
            {
                MessageBox.Show("Không được để trống ngày bắt đầu");
                dateTimePicker1.Focus();
                return false;
            }

            if (dateTimePicker2.CustomFormat == " ")
            {
                MessageBox.Show("Không được để trống ngày kết thúc");
                dateTimePicker2.Focus();
                return false;
            }

            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("ngày kết thúc phải diễn ra sau ngày bắt đầu");
                dateTimePicker2.Focus();
                return false;
            }

            return true;
            // được thì làm màu báo lỗi cho mấy viền
        }

        private void new_id()
        {
            if (VoucherBUS.VoucherList.Rows.Count > 0)
            {
                txtID.Text = ((int)VoucherBUS.VoucherList.Rows[VoucherBUS.VoucherList.Rows.Count - 1]["ID"] + 1).ToString();
                return;
            }
            txtID.Text = "100";
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "START_DATE" || dataGridView1.Columns[e.ColumnIndex].Name == "END_DATE")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
    }


}
