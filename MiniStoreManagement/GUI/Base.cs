using MiniStoreManagement.BUS;
using MiniStoreManagement.DAO;
using MiniStoreManagement.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement
{
    public partial class frmBase : Form
    {
        public string pass;
        public string user;
        AdminBUS adminBUS = new AdminBUS();
        public frmBase()
        {
            InitializeComponent();
            adminBUS.getAdmin();
            //ConnectSQL conn = new ConnectSQL();
            //DataTable temp = conn.ReadData2("select * from employee where TYPE = '1'");
            //pass = temp.Rows[0][0].ToString();
            //user = temp.Rows[0][3].ToString();
            //MessageBox.Show(user);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Password";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Tài Khoản và Mật Khẩu không được trống");
            }
            else if (adminBUS.checkAdmin(user, pass))
            {
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat; // Chọn một màu không nên xuất hiện

            // Đặt màu chính thức sẽ trở nên trong suốt
            this.TransparencyKey = Color.Wheat;
        }
    }
}
