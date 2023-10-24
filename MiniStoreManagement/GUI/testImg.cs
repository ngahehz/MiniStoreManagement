using Google.Protobuf;
using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement.GUI
{
    public partial class testImg : Form
    {
        private string fileName;
        private static EmployeeBUS empbus;
        static testImg _obj;

        public static testImg Instance
        {
            get
            {
                if (_obj == null)
                    _obj = new testImg();
                return _obj;
            }
        }

        public Panel PanelCon
        {
            get { return panel1; }
            set { panel1 = value; }
        }

        public System.Windows.Forms.Button BackBut
        {
            get { return button7; }
            set { button7 = value; }
        }


        public testImg()
        {
            InitializeComponent();
        }

        private void testImg_Load(object sender, EventArgs e)
        {
            empbus = new EmployeeBUS();
            empbus.getEmployee();

            dataGridView1.DataSource = EmployeeBUS.EmployeeList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[2].HeaderText = "GENDER";
            dataGridView1.Columns[3].HeaderText = "DOB";
            dataGridView1.Columns[4].HeaderText = "CELL";
            dataGridView1.Columns[5].HeaderText = "IMG";

            button7.Visible = false;
            _obj = this;


            //EmployeeBUS.EmployeeList.Rows[0][0].ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Img Files (*.jpg;*.png;.*.gif;)|*.jpg;*.png;.*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = Path.GetFileName(ofd.FileName);
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (pictureBox1.Image != null)
            //{
            //    string filePath = "..//..//Img//Employee//" + fileName;
            //    pictureBox1.Image.Save(filePath);
            //}
            //else
            //    MessageBox.Show("khong có ảnh");

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
                    MessageBox.Show("Lưu ảnh thành công.");
                }
            }
            else
                MessageBox.Show("Không có ảnh.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap("..//..//Img//Employee//" + fileName);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string gender = textBox3.Text;
            DateTime dob = dateTimePicker1.Value;
            string cell = textBox5.Text;
            string img = fileName;

            EmployeeDTO employee = new EmployeeDTO(id, name, gender, dob, cell, img);
            if (empbus.addEmployee(employee))
            {
                dataGridView1.Rows.Add(employee.Id, employee.Name, employee.Gender, employee.DoB, employee.Cell, employee.Img);
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm không thành công do dữ liệu bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void dataGridView1_Click(object sender, EventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            //DateTime dt = DateTime.ParseExact(dataGridView1.CurrentRow.Cells[3].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            //string day = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //DateTime newValue;
            //if(DateTime.TryParseExact(day, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newValue))
            //{
            //    dateTimePicker1.Value = newValue;
            //    MessageBox.Show("ok");
            //}

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());


            pictureBox1.Image = new Bitmap("..//..//Img//Employee//" + dataGridView1.CurrentRow.Cells[6].Value.ToString());
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DOB") // Thay "ColumnNameOfDateTimeColumn" bằng tên cột DateTime thực tế của bạn
            {
                // Kiểm tra giá trị trong ô có phải là DateTime không
                if (e.Value != null && e.Value is DateTime)
                {
                    // Định dạng DateTime theo "dd/MM/yyyy"
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true; // Đánh dấu rằng định dạng đã được áp dụng
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            dateTimePicker1.ResetText();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls["test"].BringToFront();
            button7.Visible= false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            test ts = new test();
            ts.Dock = DockStyle.Fill;
            panel1.Controls.Add(ts);
        }



        //private byte[] converImgToByte()
        //{
        //    FileStream fs;
        //    fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
        //    byte[] picbyte = new byte[fs.Length];
        //    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
        //    fs.Close();
        //    return picbyte;
        //}
    }
}
