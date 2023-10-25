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
    public partial class EmployeeUC : UserControl
    {
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private string fileName;
        private bool id_focus = false;
        public EmployeeUC()
        {
            InitializeComponent();
        }
        private void EmployeeUC_Load(object sender, EventArgs e)
        {
            if (EmployeeBUS.EmployeeList == null)
                employeeBUS.getEmployee();
            new_id();

            dataGridView1.DataSource = EmployeeBUS.EmployeeList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[2].HeaderText = "GENDER";
            dataGridView1.Columns[3].HeaderText = "DOB";
            dataGridView1.Columns[4].HeaderText = "CELL";
            dataGridView1.Columns[5].HeaderText = "IMG";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Img Files (*.jpg;*.png;*.gif;.*.svg;)|*.jpg;*.png;*.gif;*.svg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = Path.GetFileName(ofd.FileName);
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackgroundImage = new Bitmap("D:/C#/MiniStoreManagement/MiniStoreManagement/Resources/vòng tròn.png");
                //pictureBox1.BackgroundImage = null;

            }
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

            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() != "")
            {
                pictureBox1.Image = new Bitmap("..//..//Img//Employee//" + dataGridView1.CurrentRow.Cells[5].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackgroundImage = new Bitmap("D:/C#/MiniStoreManagement/MiniStoreManagement/Resources/vòng tròn.png");
            }
            else
            {
                pictureBox1.Image = null;
                fileName = null;
            }
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

            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = int.Parse(txtID.Text);
            employeeDTO.Name = txtName.Text;
            if (radioButton1.Checked)
                employeeDTO.Gender = "Nam";
            else
                employeeDTO.Gender = "Nữ";
            employeeDTO.DoB = dateTimePicker1.Value;
            employeeDTO.Cell = txtSĐT.Text;
            if (fileName != null && fileName != "")
                employeeDTO.Img = fileName;
            else
                employeeDTO.Img = null;

            if (employeeBUS.addEmployee(employeeDTO))
            {
                EmployeeBUS.EmployeeList.Rows.Add(employeeDTO.Id, employeeDTO.Name, employeeDTO.Gender, employeeDTO.DoB, employeeDTO.Cell, employeeDTO.Img);
                dataGridView1.DataSource = EmployeeBUS.EmployeeList;
                SaveImg();
                id_focus = true;
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtName.ResetText();
            txtSĐT.ResetText();
            radioButton1.Checked = true;
            pictureBox1.Image = null;
            fileName = null;
            textBox1.ResetText();
            dateTimePicker1.CustomFormat = " ";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset_form();
        }

        private bool check()
        {
            if (txtName.Text == "")
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

            if (DateTime.Now.Year - dateTimePicker1.Value.Year < 18)
            {
                MessageBox.Show("Người này chưa đủ tuổi vào làm");
                dateTimePicker1.Focus();
                return false;
            }

            return true;
                // được thì làm màu báo lỗi cho mấy viền
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id_focus)
                employeeBUS.removeEmployee(txtID.Text);
            else
                MessageBox.Show("Đối tượng này chưa được lưu vào danh sách nên không thể xóa");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = EmployeeBUS.EmployeeList.DefaultView;
            string txt = textBox1.Text;

            if (textBox1.Text == "")
            {
                dv.RowFilter = "GENDER LIKE '%N%'";
                dataGridView1.DataSource = dv.ToTable();

                return;
            }

            dv.RowFilter = $"CONVERT(ID, 'System.String') LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR GENDER LIKE '%{txt}%' OR CELL LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void LoadData(string query)
        {
            DataView dv = EmployeeBUS.EmployeeList.DefaultView;
            dv.RowFilter = query;
            //dv.RowFilter = "NAME = '%{lan}%' OR GENDER = '%{Nam}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimKiemEmployee timkiem = new TimKiemEmployee();
            timkiem.temp = new TimKiemEmployee.truyenDuLieu(LoadData);
            timkiem.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.CustomFormat == " ")
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void new_id()
        {
            if (EmployeeBUS.EmployeeList.Rows.Count > 0)
            {
                txtID.Text = ((int)EmployeeBUS.EmployeeList.Rows[EmployeeBUS.EmployeeList.Rows.Count - 1]["ID"] + 1).ToString();
                return;
            }
            txtID.Text = "10000";
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(!id_focus)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể sửa");
                return;
            }
            if (!check())
                return;

            //DataRow[] rowsToUpdate = EmployeeBUS.EmployeeList.Select("ID = 2");

            //foreach (DataRow row in rowsToUpdate)
            //{
            //    row["Name"] = "Updated Name";
            //    row["Age"] = 28;
            //}
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = int.Parse(txtID.Text);
            employeeDTO.Name = txtName.Text;
            employeeDTO.DoB = dateTimePicker1.Value;
            if (radioButton1.Checked)
                employeeDTO.Gender = "Nam";
            else
                employeeDTO.Gender = "Nữ";
            employeeDTO.Cell = txtSĐT.Text;
            if (fileName != null && fileName != "")
                employeeDTO.Img = fileName;
            else
                employeeDTO.Img = null;

            if (employeeBUS.updateEmployee(employeeDTO))
            {
                DataRow rowToUpdate = EmployeeBUS.EmployeeList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == int.Parse(txtID.Text));

                if (rowToUpdate != null)
                {
                    rowToUpdate[1] = employeeDTO.Name;
                    rowToUpdate[2] = employeeDTO.Gender;
                    rowToUpdate[3] = employeeDTO.DoB;
                    rowToUpdate[4] = employeeDTO.Cell;
                    rowToUpdate[5] = employeeDTO.Img;
                }
                dataGridView1.DataSource = EmployeeBUS.EmployeeList;
                SaveImg();
            }
            else
                MessageBox.Show("không thể sửa theo yêu cầu");
        }

        private void SaveImg()
        {
            if (pictureBox1.Image != null && fileName != null)
            {
                string filePath = "..//..//Img//Employee//" + fileName;
                if (File.Exists(filePath))
                {
                    MessageBox.Show("Tên ảnh đã tồn tại. Vui lòng chọn một tên khác.");
                }
                else
                {
                    pictureBox1.Image.Save(filePath);
                    //MessageBox.Show("Lưu ảnh thành công.");
                }
            }
        }
    }
}
