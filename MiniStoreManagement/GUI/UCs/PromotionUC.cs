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
        private bool id_focus = false;
        private PromotionBUS promotionBUS = new PromotionBUS();
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[2].HeaderText = "DISCRIPTION";
            dataGridView1.Columns[3].HeaderText = "PERCENT_DISCOUNT";
            dataGridView1.Columns[4].HeaderText = "START_DATE";
            dataGridView1.Columns[5].HeaderText = "END_DATE";
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
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPercent.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            reset_form();
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
            promotionDTO.Id = int.Parse(txtID.Text);
            promotionDTO.Name = txtName.Text;
            promotionDTO.Discription = txtDescription.Text;
            promotionDTO.PercentDiscount = decimal.Parse(txtPercent.Text);
            promotionDTO.StartDate = dateTimePicker1.Value;
            promotionDTO.EndDate = dateTimePicker2.Value;

            if (promotionBUS.addPromotion(promotionDTO))
            {
                PromotionBUS.PromotionList.Rows.Add(promotionDTO.Id, promotionDTO.Name, promotionDTO.Discription, promotionDTO.PercentDiscount, promotionDTO.StartDate, promotionDTO.EndDate);
                dataGridView1.DataSource = PromotionBUS.PromotionList;
                id_focus = true;
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
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

            PromotionDTO promotionDTO = new PromotionDTO();
            promotionDTO.Id = int.Parse(txtID.Text);
            promotionDTO.Name = txtName.Text;
            promotionDTO.Discription = txtDescription.Text;
            promotionDTO.PercentDiscount = decimal.Parse(txtPercent.Text);
            promotionDTO.StartDate = dateTimePicker1.Value;
            promotionDTO.EndDate = dateTimePicker2.Value;

            if (promotionBUS.updatePromotion(promotionDTO))
            {
                DataRow rowToUpdate = PromotionBUS.PromotionList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == int.Parse(txtID.Text));

                if (rowToUpdate != null)
                {
                    rowToUpdate[1] = promotionDTO.Name;
                    rowToUpdate[2] = promotionDTO.Discription;
                    rowToUpdate[3] = promotionDTO.PercentDiscount;
                    rowToUpdate[4] = promotionDTO.StartDate;
                    rowToUpdate[5] = promotionDTO.EndDate;
                }
                dataGridView1.DataSource = PromotionBUS.PromotionList;
            }
            else
                MessageBox.Show("không thể sửa theo yêu cầu");
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id_focus)
                promotionBUS.removePromotion(txtID.Text);
            else
                MessageBox.Show("Đối tượng này chưa được lưu vào danh sách nên không thể xóa");
        }
        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtName.ResetText();
            txtDescription.ResetText();
            txtPercent.ResetText();
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";
            txtTimKiem.ResetText();
        }

        

        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Không được để trống mô tả");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPercent.Text))
            {
                MessageBox.Show("Không được để trống chiết khấu");
                txtName.Focus();
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
            // được thì làm màu báo lỗi cho mấy viền
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = PromotionBUS.PromotionList.DefaultView;
            string txt = txtTimKiem.Text;

            if (txtTimKiem.Text == "")
            {
                dv.RowFilter = "CONVERT(ID, 'System.String') LIKE '%{1}%'";
                dataGridView1.DataSource = dv.ToTable();

                return;
            }

            dv.RowFilter = $"CONVERT(ID, 'System.String') LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR DISCRIPTION LIKE '%{txt}%' OR CONVERT(PERCENT_DISCOUNT, 'System.String') LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void LoadData(string query)
        {
            DataView dv = PromotionBUS.PromotionList.DefaultView;
            dv.RowFilter = query;
            dataGridView1.DataSource = dv.ToTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimKiemEmployee timkiem = new TimKiemEmployee();
            timkiem.temp = new TimKiemEmployee.truyenDuLieu(LoadData);
            timkiem.Show();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void new_id()
        {
            if (PromotionBUS.PromotionList.Rows.Count > 0)
            {
                txtID.Text = ((int)PromotionBUS.PromotionList.Rows[PromotionBUS.PromotionList.Rows.Count - 1]["ID"] + 1).ToString();
                return;
            }
            txtID.Text = "1000";
        }

        
    }
}
