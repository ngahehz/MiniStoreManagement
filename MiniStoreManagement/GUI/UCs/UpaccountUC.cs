using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml.Linq;
using MiniStoreManagement.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class UpaccountUC : UserControl
    {
        private AdminBUS adminBUS = new AdminBUS();
        private bool id_focus = false;
        public UpaccountUC()
        {
            InitializeComponent();
            adminBUS.getAdmin();
        }

        private void BtnUpdatead_Click(object sender, EventArgs e)
        {

            if (!checkacc())
                return;

            if (adminBUS.checkAdmin(txtunameup.Text, txtmkup.Text))
            {
                AdminDTO accountDTO = new AdminDTO();
                accountDTO.PASSWORD = txtpassnew.Text;
                accountDTO.USERNAME = txtunameup.Text;

                if (adminBUS.updateAdmin(accountDTO))
                {
                    DataRow rowToUpdate = AdminBUS.AdminList.AsEnumerable().FirstOrDefault(row => row.Field<string>("UNAME") == txtunameup.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[3] = accountDTO.PASSWORD;
                   

                    }
                    MessageBox.Show("Đã thay đổi");
                    reset_form();

                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
            else
            {
                MessageBox.Show("Sai thông tin");
            }

        }
        private bool checkacc()
        {
            if (txtpassnew.Text == "")
            {
                MessageBox.Show("Không được để trống mật khẩu");
                txtpassnew.Focus();
                return false;
            }

         
            return true;
        }
        private void reset_form()
        {
            id_focus = false;
            txtupid.ResetText();
           
            txtpassnew.ResetText();
        }

        private void BtnUpdatead_Click_1(object sender, EventArgs e)
        {
            if (!checkacc())
                return;

            if (adminBUS.checkAdmin(txtunameup.Text, txtmkup.Text))
            {
                AdminDTO adminDTO = new AdminDTO();
                adminDTO.PASSWORD = txtpassnew.Text;
                adminDTO.USERNAME = txtunameup.Text;

                if (adminBUS.updateAdmin(adminDTO))
                {
                    DataRow rowToUpdate = AdminBUS.AdminList.AsEnumerable().FirstOrDefault(row => row.Field<string>("USERNAME") == txtunameup.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[3] = adminDTO.PASSWORD;
                    }
                    MessageBox.Show("Đã thay đổi");
                    reset_form();

                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
            else
            {
                MessageBox.Show("Sai thông tin");
            }
        }
    }
}
