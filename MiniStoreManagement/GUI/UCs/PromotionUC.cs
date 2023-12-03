using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.FormSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class PromotionUC : UserControl
    {
        private PromotionBUS promotionBUS = new PromotionBUS();
        private bool id_focus = false;
        private string _state = "1";
        public PromotionUC()
        {
            InitializeComponent();
        }

        public PromotionUC(string i)
        {
            InitializeComponent();

            _state = i;
            BtnUpdate.Visible = false;
            btnAdd.Visible = false;
            btnNew.Text = "Xóa";
            btnDel.Text = "Hoàn";
            txtDescription.ReadOnly = true;
            txtPercent.ReadOnly = true;
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

        private void PromotionUC_Load(object sender, EventArgs e)
        {
            if (PromotionBUS.PromotionList == null)
                promotionBUS.getPromotion();

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
            if (show_data().Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
                return;

            id_focus = true;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPercent.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
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

            PromotionDTO promotionDTO = new PromotionDTO();
            promotionDTO.Id = txtID.Text;
            promotionDTO.Discription = txtDescription.Text;
            promotionDTO.PercentDiscount = double.Parse(txtPercent.Text);
            promotionDTO.StartDate = dateTimePicker1.Value;
            promotionDTO.EndDate = dateTimePicker2.Value;

            if (promotionBUS.addPromotion(promotionDTO))
            {
                PromotionBUS.PromotionList.Rows.Add(promotionDTO.Id, promotionDTO.Discription, promotionDTO.PercentDiscount,
                                                    promotionDTO.StartDate, promotionDTO.EndDate, promotionDTO.State);
                showdata();
                id_focus = true;
                MessageBox.Show("Thêm thành công");
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
                    if (promotionBUS.removePromotion(txtID.Text))
                    {
                        DataRow[] rowsToDelete = PromotionBUS.PromotionList.Select("ID = '" + txtID.Text + "'");
                        PromotionBUS.PromotionList.Rows.Remove(rowsToDelete[0]);
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
                DataRow rowToUpdate = PromotionBUS.PromotionList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                PromotionDTO promotionDTO = new PromotionDTO(rowToUpdate);
                promotionDTO.State = _state; 

                if (promotionBUS.updatePromotion(promotionDTO))
                {
                    rowToUpdate[5] = _state;
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
                PromotionDTO promotionDTO = new PromotionDTO();
                promotionDTO.Id = txtID.Text;
                promotionDTO.Discription = txtDescription.Text;
                promotionDTO.PercentDiscount = double.Parse(txtPercent.Text);
                promotionDTO.StartDate = dateTimePicker1.Value;
                promotionDTO.EndDate = dateTimePicker2.Value;

                if (promotionBUS.updatePromotion(promotionDTO))
                {
                    DataRow rowToUpdate = PromotionBUS.PromotionList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = promotionDTO.Discription;
                        rowToUpdate[2] = promotionDTO.PercentDiscount;
                        rowToUpdate[3] = promotionDTO.StartDate;
                        rowToUpdate[4] = promotionDTO.EndDate;
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
                dv.RowFilter = "ID LIKE '%{1}%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR DISCRIPTION LIKE '%{txt}%' OR CONVERT(PERCENT_DISCOUNT, 'System.String') LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TimKiemPromotion"] != null)
                return;
            TimKiemPromotion timkiem = new TimKiemPromotion();
            timkiem.temp = new TimKiemPromotion.truyenDuLieu(LoadData);
            timkiem.Show();
        }

        private int LoadData(string query)
        {
            DataView dv = show_data().DefaultView;
            dv.RowFilter = query;
            dataGridView1.DataSource = dv.ToTable();
            return dv.ToTable().Rows.Count;
        }

        private void new_id()
        {
            if (PromotionBUS.PromotionList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(PromotionBUS.PromotionList.Rows[PromotionBUS.PromotionList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID.Text = "1000";
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtDescription.ResetText();
            txtPercent.ResetText();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";
            txtSearch.ResetText();
        }

        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Không được để trống mô tả");
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPercent.Text))
            {
                MessageBox.Show("Không được để trống chiết khấu");
                txtPercent.Focus();
                return false;
            }

            if (!double.TryParse(txtPercent.Text, out double number) || number <= 0 || number >= 1)
            {
                MessageBox.Show("Chiếu khấu phải lại một số thập phân trong khoảng 0 đến 1");
                return false;
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
                var filteredRows1 = PromotionBUS.PromotionList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : PromotionBUS.PromotionList.Clone();
            }
            var filteredRows = PromotionBUS.PromotionList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : PromotionBUS.PromotionList.Clone();
        }

        public void showdata()
        {
            dataGridView1.DataSource = show_data();
        }
    }
}

