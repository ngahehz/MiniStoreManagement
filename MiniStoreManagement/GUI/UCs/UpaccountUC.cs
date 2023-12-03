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

namespace MiniStoreManagement.GUI.UCs
{
    public partial class UpaccountUC : UserControl
    {
        private AdminBUS adminBUS = new AdminBUS();
        public UpaccountUC()
        {
            InitializeComponent();
            adminBUS.getAdmin();
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
                        rowToUpdate[2] = adminDTO.PASSWORD;
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
