using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.FormSP;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiniStoreManagement.GUI.UCs
{
    public partial class EmployeeUC : UserControl
    {
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private string fileName;
        private bool id_focus = false;
        private string _state = "1";
        public EmployeeUC()
        {
            InitializeComponent();
        }

        public EmployeeUC(string i)
        {
            InitializeComponent();

            _state = i;
            txtSĐT.ReadOnly = true;
            txtName.ReadOnly = true;
            radioButton2.Enabled = false;
            dateTimePicker1.Enabled = false;

            button1.Visible = false;
            btnAdd.Visible = false;
            BtnUpdate.Visible = false;
            btnNew.Text = "Xóa";
            btnDel.Text = "Hoàn";
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

        private void EmployeeUC_Load(object sender, EventArgs e)
        {
            if (EmployeeBUS.EmployeeList == null)
                employeeBUS.getEmployee();
            new_id();

            showdata();
            dataGridView1.Columns["STATE"].Visible = false;
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
            reset_form();
            if (show_data().Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
                return;

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

            if (!string.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[5].Value.ToString()))
            {
                pictureBox1.Image = new Bitmap("..//..//Img//Employee//" + dataGridView1.CurrentRow.Cells[5].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                //pictureBox1.BackgroundImage = null;
                //fileName = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                fileName = Path.GetExtension(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            }
            else
            {
                pictureBox1.Image = null;
                fileName = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Img Files (*.jpg;*.png;*.gif;.*.svg;)|*.jpg;*.png;*.gif;*.svg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = Path.GetExtension(ofd.FileName);
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                //pictureBox1.BackgroundImage = null;
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
            employeeDTO.Id = txtID.Text;
            employeeDTO.Name = txtName.Text;
            if (radioButton1.Checked)
                employeeDTO.Gender = "Nam";
            else
                employeeDTO.Gender = "Nữ";
            employeeDTO.DoB = dateTimePicker1.Value;
            employeeDTO.Cell = txtSĐT.Text;

            if (!string.IsNullOrEmpty(fileName))
                employeeDTO.Img = txtID.Text + fileName;
            else
                employeeDTO.Img = null;

            if (employeeBUS.addEmployee(employeeDTO))
            {
                //EmployeeBUS.EmployeeList.Rows.Add(employeeDTO);
                EmployeeBUS.EmployeeList.Rows.Add(employeeDTO.Id, employeeDTO.Name, employeeDTO.Gender, employeeDTO.DoB, employeeDTO.Cell, employeeDTO.Img, employeeDTO.State);

                showdata();
                SaveImg(employeeDTO.Id);
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
                    if (employeeBUS.removeEmployee(txtID.Text))
                    {


                        DataRow[] rowsToDelete = EmployeeBUS.EmployeeList.Select("ID = '" + txtID.Text + "'");

                        if (!string.IsNullOrEmpty(rowsToDelete[7].ToString()))
                        {
                            string filePath = "..//..//Img//Employee//" + rowsToDelete[7].ToString();
                            if (File.Exists(filePath))
                                File.Delete(filePath);
                        }

                        EmployeeBUS.EmployeeList.Rows.Remove(rowsToDelete[0]);
                        showdata();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                        MessageBox.Show("Không thể xóa đối tượng!");
                }
            }
            else
            {
                dataGridView1.ClearSelection();
                reset_form();
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
                DataRow rowToUpdate = EmployeeBUS.EmployeeList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                EmployeeDTO employeeDTO = new EmployeeDTO(rowToUpdate);
                if (rowToUpdate != null)
                {
                    employeeDTO.State = _state;
                    if (employeeBUS.updateEmployee(employeeDTO))
                    {
                        rowToUpdate[6] = _state;
                        showdata();
                        reset_form();

                        if (_state == "1")
                            MessageBox.Show("Đã xóa");
                        else
                            MessageBox.Show("Đã khôi phục");
                    }
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
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.Id = txtID.Text;
                employeeDTO.Name = txtName.Text;
                employeeDTO.DoB = dateTimePicker1.Value;
                if (radioButton1.Checked)
                    employeeDTO.Gender = "Nam";
                else
                    employeeDTO.Gender = "Nữ";
                employeeDTO.Cell = txtSĐT.Text;
                if (!string.IsNullOrEmpty(fileName))
                    employeeDTO.Img = txtID.Text + fileName;
                else
                    employeeDTO.Img = null;

                if (employeeBUS.updateEmployee(employeeDTO))
                {
                    DataRow rowToUpdate = EmployeeBUS.EmployeeList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = employeeDTO.Name;
                        rowToUpdate[2] = employeeDTO.Gender;
                        rowToUpdate[3] = employeeDTO.DoB;
                        rowToUpdate[4] = employeeDTO.Cell;
                        if (employeeDTO.Img != null)
                            rowToUpdate[5] = employeeDTO.Img;

                        showdata();

                        SaveImg(employeeDTO.Id);
                        MessageBox.Show("Đã sửa");
                    }
                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = show_data().DefaultView;
            string txt = textBox1.Text;

            if (textBox1.Text == "")
            {
                dv.RowFilter = "GENDER LIKE '%N%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }
            dv.RowFilter = $"ID LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR GENDER LIKE '%{txt}%' OR CELL LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void new_id()
        {
            if (EmployeeBUS.EmployeeList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(EmployeeBUS.EmployeeList.Rows[EmployeeBUS.EmployeeList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID.Text = "10000";
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = " ";
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

            if (DateTime.Now.Year - dateTimePicker1.Value.Year < 18)
            {
                MessageBox.Show("Người này chưa đủ tuổi vào làm");
                dateTimePicker1.Focus();
                return false;
            }

            return true;
            // được thì làm màu báo lỗi cho mấy viền
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.CustomFormat == " ")
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void SaveImg(string name)
        {
            if (pictureBox1.Image != null && fileName != null)
            {
                string filePath = "..//..//Img//Employee//" + name + fileName;

                if (File.Exists(filePath))
                    File.Delete(filePath);

                pictureBox1.Image.Save(filePath);
            }
        }

        public void showdata()
        {
            dataGridView1.DataSource = show_data();
        }

        private DataTable show_data()
        {
            if (_state == "0")
            {
                var filteredRows1 = EmployeeBUS.EmployeeList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : EmployeeBUS.EmployeeList.Clone();
            }

            var filteredRows = EmployeeBUS.EmployeeList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : EmployeeBUS.EmployeeList.Clone();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            fileName = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
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

        private void btneexcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }
        /*private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý nhân viên";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        //MessageBox.Show(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }*/

        private void btniexcel_Click(object sender, EventArgs e)
        {
            /* try
             {
                 using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel WorkBook |*.xls|Excel WorkBook|*.xlsx", ValidateNames = true })
                 {
                     if (ofd.ShowDialog() == DialogResult.OK)
                     {
                         EmployeeDTO employeeDTO = new EmployeeDTO();
                         String name = "Sheet1";
                         String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                         ofd.FileName +
                                         ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                         if (id_focus)
                         {
                             MessageBox.Show("Ấn nút mới để tạo mới form");
                             return;
                         }


                         if (employeeBUS.addEmployee(employeeDTO))
                         {
                             //EmployeeBUS.EmployeeList.Rows.Add(employeeDTO);
                             EmployeeBUS.EmployeeList.Rows.Add(employeeDTO.Id, employeeDTO.Name, employeeDTO.Gender, employeeDTO.DoB, employeeDTO.Cell, employeeDTO.Img, employeeDTO.State);

                             showdata();
                             SaveImg();
                             id_focus = true;
                             MessageBox.Show("Thêm thành công");
                         }
                         else
                             MessageBox.Show("Lỗi không thể thêm thành công");
                     }
                 }
             }
             catch (Exception ex) { string errormsg = ex.ToString(); }*/

            //Import Excel file and Save data to a table in Database



        }

        
    }
}
    
    


// TÌM KIẾM NÂNG CAO

//private void LoadData(string query)
//{
//    DataView dv = show_data().DefaultView;
//    dv.RowFilter = query;
//    //dv.RowFilter = "NAME = '%{lan}%' OR GENDER = '%{Nam}%'";
//    dataGridView1.DataSource = dv.ToTable();
//}

//private void button2_Click(object sender, EventArgs e)
//{
//    TimKiemEmployee timkiem = new TimKiemEmployee();
//    timkiem.temp = new TimKiemEmployee.truyenDuLieu(LoadData);
//    timkiem.Show();
//}



// HIỂN THỊ BẢNG BAN ĐẦU

//DataRow[] filteredRows = EmployeeBUS.EmployeeList.Select("STATE = 0");

//DataTable dataGridViewDataTable = EmployeeBUS.EmployeeList.Clone();
//foreach (DataRow row in filteredRows)
//{
//    dataGridViewDataTable.ImportRow(row);
//}
//return dataGridViewDataTable;

//DataTable dataGridView2DataTable = EmployeeBUS.EmployeeList.Clone();
//foreach (DataRow row in EmployeeBUS.EmployeeList.Rows)
//{
//    if (!filteredRows.Contains(row))
//    {
//        dataGridView2DataTable.ImportRow(row);
//    }
//}