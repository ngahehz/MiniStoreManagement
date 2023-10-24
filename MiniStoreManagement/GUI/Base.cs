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
        public frmBase()
        {
            InitializeComponent();
            //ConnectSQL conn = new ConnectSQL();
            //DataTable temp = conn.ReadData2("select * from employee where TYPE = '1'");
            //pass = temp.Rows[0][0].ToString();
            //user = temp.Rows[0][3].ToString();
            //MessageBox.Show(user);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            //if (txtPassword.Text == pass && txtUsername.Text == user)
            //    MessageBox.Show("chuẩn acc");
            //else
            //    MessageBox.Show("sai òi");
            testImg testImg = new testImg();
            testImg.Show();
        }
    }
}
