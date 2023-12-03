using MiniStoreManagement.BUS;
using MiniStoreManagement.DAO;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class VoucherUC : UserControl
    {
        private VoucherBUS voucherBUS = new VoucherBUS();
        private bool id_focus = false; // để khi nào mà đang ấn một id nào đó thì không cho phép thêm từ đối tượng đó.
        private string _state = "1";
        public VoucherUC()
        {
            InitializeComponent();
        }

        public VoucherUC(string i)
        {
            InitializeComponent();

            _state = i;
            BtnUpdate.Visible = false;
            btnAdd.Visible = false;
            btnNew.Text = "Xóa";
            btnDel.Text = "Hoàn";
            txtDescription.Enabled = false;
            txtChietkhau.Enabled = false;
            txtGiagiam.Enabled = false;
            txtGTTT.Enabled = false;
            txtGTTĐ.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            make_center();
        }

        public void make_center()
        {
            int spacing = 45;
            int panelHeight = panel2.Height;
            int buttonHeight = btnAdd.Height;

            int yPositionButton1 = (panelHeight - buttonHeight * 2 - spacing) / 2;
            int yPositionButton2 = yPositionButton1 + buttonHeight + spacing;

            btnNew.Location = new Point(btnAdd.Location.X, yPositionButton1);

            btnDel.Location = new Point(btnDel.Location.X, yPositionButton2);
        }

        private void VoucherUC_Load(object sender, EventArgs e)
        {
            if (VoucherBUS.VoucherList == null)
                voucherBUS.getVoucher();

            new_id();
            showdata();
            dataGridView1.Columns["STATE"].Visible = false;
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            reset_form();
            if (VoucherBUS.VoucherList.Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
                return;

            id_focus = true;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            if (string.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[3].Value.ToString()))
            {
                radioButton2.Checked = true;
                txtChietkhau.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtGTTĐ.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                radioButton1.Checked = true;
                txtGiagiam.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtGTTT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
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
            voucherDTO.Id = txtID.Text;
            voucherDTO.Code = txtCode.Text;
            voucherDTO.Discription = txtDescription.Text;
            if (radioButton1.Checked)
            {
                voucherDTO.DiscountAmount = decimal.Parse(txtGiagiam.Text);
                voucherDTO.MinInvoiceValue = decimal.Parse(txtGTTT.Text);
                voucherDTO.PercentDiscount = null;
                voucherDTO.MaxDiscount = null;
            }
            else
            {
                voucherDTO.DiscountAmount = null;
                voucherDTO.MinInvoiceValue = null;
                voucherDTO.PercentDiscount = double.Parse(txtChietkhau.Text);
                voucherDTO.MaxDiscount = decimal.Parse(txtGTTĐ.Text);
            }

            voucherDTO.StartDate = dateTimePicker1.Value;
            voucherDTO.EndDate = dateTimePicker2.Value;

            if (voucherBUS.addVoucher(voucherDTO))
            {
                VoucherBUS.VoucherList.Rows.Add(voucherDTO.Id, voucherDTO.Code, voucherDTO.Discription, voucherDTO.DiscountAmount, voucherDTO.MinInvoiceValue,
                                                voucherDTO.PercentDiscount, voucherDTO.MaxDiscount, voucherDTO.StartDate, voucherDTO.EndDate, voucherDTO.State);

                showdata();
                id_focus = true;
                MessageBox.Show("Thêm thành công!");
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_state == "0")
            {
                if (!id_focus)
                {
                    MessageBox.Show("Chưa chọn đối tượng, không thể xóa");
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (voucherBUS.removeVoucher(txtID.Text))
                    {
                        DataRow[] rowsToDelete = VoucherBUS.VoucherList.Select("ID = '" + txtID.Text + "'");
                        VoucherBUS.VoucherList.Rows.Remove(rowsToDelete[0]);
                        showdata();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                        MessageBox.Show("Không thể xóa đối tượng!");
                }
            }
            else
            {
                reset_form();
                dataGridView1.ClearSelection();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!id_focus)
            {
                if (_state == "1")
                {
                    MessageBox.Show("Đối tượng chưa được lưu nên không thể xóa");
                    return;
                }
                else
                {
                    MessageBox.Show("Chưa chọn đối tượng, không thể phục hồi");
                    return;
                }
            }


            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataRow rowToUpdate = VoucherBUS.VoucherList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                VoucherDTO voucherDTO = new VoucherDTO(rowToUpdate);
                voucherDTO.State = _state;

                if (voucherBUS.updateVoucher(voucherDTO))
                {
                    rowToUpdate[9] = _state;
                    showdata();
                    reset_form();

                    if (_state == "1")
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Đã khôi phục");
                }
                else
                    MessageBox.Show("không thể làm theo yêu cầu");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!id_focus)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể sửa");
                return;
            }
            if (!check())
                return;

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                VoucherDTO voucherDTO = new VoucherDTO();

                voucherDTO.Id = txtID.Text;
                voucherDTO.Code = txtCode.Text;
                voucherDTO.Discription = txtDescription.Text;
                if (radioButton1.Checked)
                {
                    voucherDTO.DiscountAmount = decimal.Parse(txtGiagiam.Text);
                    voucherDTO.MinInvoiceValue = decimal.Parse(txtGTTT.Text);
                    voucherDTO.PercentDiscount = null;
                    voucherDTO.MaxDiscount = null;
                }
                else
                {
                    voucherDTO.DiscountAmount = null;
                    voucherDTO.MinInvoiceValue = null;
                    voucherDTO.PercentDiscount = double.Parse(txtChietkhau.Text);
                    voucherDTO.MaxDiscount = decimal.Parse(txtGTTĐ.Text);
                }

                voucherDTO.StartDate = dateTimePicker1.Value;
                voucherDTO.EndDate = dateTimePicker2.Value;


                if (voucherBUS.updateVoucher(voucherDTO))
                {
                    DataRow rowToUpdate = VoucherBUS.VoucherList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = voucherDTO.Code;
                        rowToUpdate[2] = voucherDTO.Discription;
                        rowToUpdate[3] = voucherDTO.DiscountAmount;
                        rowToUpdate[4] = voucherDTO.MinInvoiceValue;
                        rowToUpdate[5] = voucherDTO.PercentDiscount;
                        rowToUpdate[6] = voucherDTO.MaxDiscount;
                        rowToUpdate[7] = voucherDTO.StartDate;
                        rowToUpdate[8] = voucherDTO.EndDate;
                    }
                    showdata();
                    MessageBox.Show("Đã sửa");
                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = show_data().DefaultView;
            string txt = txtSearch.Text;

            if (txtSearch.Text == "")
            {
                dv.RowFilter = "ID LIKE '%1%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR CODE LIKE '%{txt}%' OR DISCRIPTION LIKE '%{txt}%' OR CONVERT(DISCOUNT_AMOUNT, 'System.String') LIKE '%{txt}%'"
                + $" OR CONVERT(MIN_INVOICE_VALUE, 'System.String') LIKE '%{txt}%' OR CONVERT(PERCENT_DISCOUNT, 'System.String') LIKE '%{txt}%' OR CONVERT(MAX_DISCOUNT, 'System.String') LIKE '%{txt}%' ";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtGiagiam.Enabled = true;
                txtGTTT.Enabled = true;
                txtChietkhau.Enabled = false;
                txtGTTĐ.Enabled = false;
            }
            else
            {
                txtGiagiam.Enabled = false;
                txtGTTT.Enabled = false;
                txtChietkhau.Enabled = true;
                txtGTTĐ.Enabled = true;
            }
            if (_state == "1")
            {
                return;
            }

            if (radioButton2.Checked)
            {
                radioButton2.Enabled = true;
                radioButton1.Enabled = false;
            }
            else
            {
                radioButton2.Enabled = false;
                radioButton1.Enabled = true;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void new_id()
        {
            if (VoucherBUS.VoucherList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(VoucherBUS.VoucherList.Rows[VoucherBUS.VoucherList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID.Text = "100";
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtCode.ResetText();
            txtDescription.ResetText();
            txtSearch.ResetText();
            radioButton1.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";
        }

        private bool check()
        {
            decimal number;
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
            if (radioButton1.Checked)
            {

                if (string.IsNullOrWhiteSpace(txtGiagiam.Text))
                {
                    MessageBox.Show("Không được để trống giá giảm");
                    txtGiagiam.Focus();
                    return false;
                }
                if (!decimal.TryParse(txtGiagiam.Text, out number))
                {
                    MessageBox.Show("Giá giảm sai định dạng, mời nhập lại!");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtGTTT.Text))
                {
                    MessageBox.Show("Không được để trống giá trị tổi thiếu");
                    txtGTTT.Focus();
                    return false;
                }
                if (!decimal.TryParse(txtGTTT.Text, out number))
                {
                    MessageBox.Show("Giá trị tối thiểu sai định dạng, mời nhập lại");
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtChietkhau.Text))
                {
                    MessageBox.Show("Không được để trống chiết khấu");
                    txtChietkhau.Focus();
                    return false;
                }
                if (!double.TryParse(txtChietkhau.Text, out double number1) || number1 <= 0 || number1 >= 1)
                {
                    MessageBox.Show("Chiếu khấu phải lại một số thập phân trong khoảng 0 đến 1");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtGTTĐ.Text))
                {
                    MessageBox.Show("Không được để trống giá giảm tối đa");
                    txtGTTĐ.Focus();
                    return false;
                }
                if (!decimal.TryParse(txtGTTĐ.Text, out number))
                {
                    MessageBox.Show("Giá giảm tối đa nhập sai định dạng, mời nhập lại");
                    return false;
                }
            }

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
        }

        private DataTable show_data()
        {
            if (_state == "0")
            {
                var filteredRows1 = VoucherBUS.VoucherList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : VoucherBUS.VoucherList.Clone();
            }
            var filteredRows = VoucherBUS.VoucherList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : VoucherBUS.VoucherList.Clone();

        }

        public void showdata()
        {
            dataGridView1.DataSource = show_data();
        }
    }
}
