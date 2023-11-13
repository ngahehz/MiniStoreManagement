using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.FormSP;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class ConsumerUC : UserControl
    {
        private ConsumerBUS consumerBUS = new ConsumerBUS();
        private bool id_focus = false;
        public ConsumerUC()
        {
            InitializeComponent();
        }

        private void ConsumerUC_Load(object sender, EventArgs e)
        {
            if (ConsumerBUS.ConsumerList == null)
                consumerBUS.getConsumer();
            new_id();

            dataGridView1.DataSource = ConsumerBUS.ConsumerList;

        }
        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DOB")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true; // Đánh dấu rằng định dạng đã được áp dụng
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

            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSĐT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Nam")
            {
                radioButton1.Checked = true;
            }
            else { radioButton2.Checked = true; }

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

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

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ConsumerDTO consumerDTO = new ConsumerDTO();
                consumerDTO.Id = txtID.Text;
                consumerDTO.Name = txtName.Text;
                if (radioButton1.Checked)
                    consumerDTO.Gender = "Nam";
                else
                    consumerDTO.Gender = "Nữ";
                consumerDTO.DoB = dateTimePicker1.Value;
                consumerDTO.Cell = txtSĐT.Text;
                if (consumerBUS.addConsumer(consumerDTO))
                {
                    //ConsumerBUS.ConsumerList.Rows.Add(consumerDTO);
                    ConsumerBUS.ConsumerList.Rows.Add(consumerDTO.Id, consumerDTO.Name, consumerDTO.Gender, consumerDTO.DoB, consumerDTO.Cell);

                    dataGridView1.DataSource = ConsumerBUS.ConsumerList;
                    id_focus = true;
                }
                else
                    MessageBox.Show("Lỗi không thể thêm thành công");
            }
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtName.ResetText();
            txtSĐT.ResetText();
            radioButton1.Checked = true;
            txtSearch.ResetText();
            dateTimePicker1.CustomFormat = " ";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset_form();
        }

        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtName.Focus();
                return false;
            }

            string pattern = @"^0\d{9}$"; //@"^(09|02|03|08)\d{8}$";
            if (!Regex.IsMatch(txtSĐT.Text, pattern))
            {
                MessageBox.Show("Sai định dạng số điện thoại");
                txtSĐT.Focus();
                return false;
            }

            if (dateTimePicker1.CustomFormat == " ")
            {
                MessageBox.Show("Không được để trống ngày sinh");
                dateTimePicker1.Focus();
                return false;
            }

            return true;
          
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!id_focus)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể xóa");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataRow rowToUpdate = ConsumerBUS.ConsumerList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                ConsumerDTO consumerDTO = new ConsumerDTO();
                if (rowToUpdate != null)
                {
                    consumerDTO.Id = txtID.Text;
                    consumerDTO.Name = rowToUpdate[1].ToString();
                    consumerDTO.Gender = rowToUpdate[2].ToString();
                    consumerDTO.DoB = DateTime.Parse(rowToUpdate[3].ToString());
                    consumerDTO.Cell = rowToUpdate[4].ToString();
                    consumerBUS.updateConsumer(consumerDTO);
                }

                dataGridView1.DataSource = ConsumerBUS.ConsumerList;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ConsumerBUS.ConsumerList.DefaultView;
            string txt = txtSearch.Text;

            if (txtSearch.Text == "")
            {
                dv.RowFilter = "GENDER LIKE '%N%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR GENDER LIKE '%{txt}%' OR CELL LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.CustomFormat == " ")
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void new_id()
        {
            if (ConsumerBUS.ConsumerList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(ConsumerBUS.ConsumerList.Rows[ConsumerBUS.ConsumerList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID.Text = "10000";
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
                ConsumerDTO consumerDTO = new ConsumerDTO();
                consumerDTO.Id = txtID.Text;
                consumerDTO.Name = txtName.Text;
                consumerDTO.DoB = dateTimePicker1.Value;
                if (radioButton1.Checked)
                    consumerDTO.Gender = "Nam";
                else
                    consumerDTO.Gender = "Nữ";
                consumerDTO.Cell = txtSĐT.Text;

                if (consumerBUS.updateConsumer(consumerDTO))
                {
                    DataRow rowToUpdate = ConsumerBUS.ConsumerList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = consumerDTO.Name;
                        rowToUpdate[2] = consumerDTO.Gender;
                        rowToUpdate[3] = consumerDTO.DoB;
                        rowToUpdate[4] = consumerDTO.Cell;
                    }

                    dataGridView1.DataSource = ConsumerBUS.ConsumerList;
                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
            
        }

    }
}
