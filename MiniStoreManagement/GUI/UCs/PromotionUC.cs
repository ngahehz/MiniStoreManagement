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
        public PromotionUC()
        {
            InitializeComponent();
        }

        private void PromotionUC_Load(object sender, EventArgs e)
        {
            if (PromotionBUS.PromotionList == null)
                promotionBUS.getPromotion();

            new_id();
            dataGridView1.DataSource = PromotionBUS.PromotionList;
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
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form();
                return;
            }
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
            promotionDTO.PercentDiscount = decimal.Parse(txtPercent.Text);
            promotionDTO.StartDate = dateTimePicker1.Value;
            promotionDTO.EndDate = dateTimePicker2.Value;

            if (promotionBUS.addPromotion(promotionDTO))
            {
                PromotionBUS.PromotionList.Rows.Add(promotionDTO.Id, promotionDTO.Discription, promotionDTO.PercentDiscount, promotionDTO.StartDate, promotionDTO.EndDate);
                dataGridView1.DataSource = PromotionBUS.PromotionList;
                id_focus = true;
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset_form();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id_focus)
            {
                DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (promotionBUS.removePromotion(txtID.Text))
                    {
                        DataRow[] rowsToDelete = PromotionBUS.PromotionList.Select("ID = '" + txtID.Text + "'");
                        PromotionBUS.PromotionList.Rows.Remove(rowsToDelete[0]);
                        dataGridView1.DataSource = PromotionBUS.PromotionList;

                        MessageBox.Show("Đã xóa");
                    }
                    else
                        MessageBox.Show("không thể làm theo yêu cầu");
                }
            }
            else
                MessageBox.Show("Đối tượng này chưa được lưu vào danh sách nên không thể xóa");
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
                promotionDTO.PercentDiscount = decimal.Parse(txtPercent.Text);
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
                    dataGridView1.DataSource = PromotionBUS.PromotionList;
                    MessageBox.Show("Đã sửa");
                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = PromotionBUS.PromotionList.DefaultView;
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
            TimKiemPromotion timkiem = new TimKiemPromotion();
            timkiem.temp = new TimKiemPromotion.truyenDuLieu(LoadData);
            timkiem.Show();
        }

        private void LoadData(string query)
        {
            MessageBox.Show(query);
            DataView dv = PromotionBUS.PromotionList.DefaultView;
            dv.RowFilter = query;
            dataGridView1.DataSource = dv.ToTable();
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
    }
}

//private DataTable show_data()
//{
//    var filteredRows = PromotionBUS.PromotionList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
//    return filteredRows.Any() ? filteredRows.CopyToDataTable() : PromotionBUS.PromotionList.Clone();
//}
