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
        AdminBUS adminBUS = new AdminBUS();
        public frmBase()
        {
            InitializeComponent();
            adminBUS.getAdmin();
            BaseEvent();
        }
        void BaseEvent()
        {
            picExit.Click += picExit_Click;
            picmini.Click += picmini_Click;
            picmax.Click += picmax_Click;
        }
        
        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void picmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void picmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
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

        private Point mouseOffset;
        private bool isDragging = false;

        private void Moving_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isDragging = true;
            }
        }
        private void Moving_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }
        private void Moving_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}

// MÀU CƯNG VÃI L

//private void lbExit_MouseHover(object sender, EventArgs e)
//{
//    lbExit.ForeColor = Color.FromArgb(255, 128, 255);
//}

//private void lbExit_MouseLeave(object sender, EventArgs e)
//{
//    lbExit.ForeColor = Color.LightCyan;
//}
