using MiniStoreManagement.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniStoreManagement.DTO;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class ListAdminUC : UserControl
    {
        private AdminBUS adminBUS = new AdminBUS();
        private bool id_focus = false;

        public ListAdminUC()
        {
            InitializeComponent();
        }

        private void ListAdminUC_Load(object sender, EventArgs e)
        {
            if (AdminBUS.AdminList == null)
                adminBUS.getAdmin();
            new_id();

            adminDataGridView.DataSource = AdminBUS.AdminList;
            adminDataGridView.Columns["PASSWORD"].Visible = false;
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtName.ResetText();
            txtUsername.ResetText();
            txtPass.ResetText();
        }

        private void new_id()
        {
            if (AdminBUS.AdminList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(AdminBUS.AdminList.Rows[AdminBUS.AdminList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID.Text = "10000";
        }

        private bool checkacc()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Không được để trống tên");
                txtName.Focus();
                return false;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Không được để trống mật khẩu");
                txtPass.Focus();
                return false;
            }
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Không được để trống tên đăng nhập");
                txtUsername.Focus();
                return false;
            }

            return true;
        }

        private void adminDataGridView_Click_1(object sender, EventArgs e)
        {
            if (adminDataGridView.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form();
                return;
            }
            id_focus = true;

            txtID.Text = adminDataGridView.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = adminDataGridView.CurrentRow.Cells[3].Value.ToString();
            txtUsername.Text = adminDataGridView.CurrentRow.Cells[1].Value.ToString() ;
            txtPass.Text = adminDataGridView.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (id_focus)
            {
                MessageBox.Show("Ấn nút mới để tạo mới form");
                return;
            }
            if (!checkacc())
                return;

            AdminDTO adminDTO = new AdminDTO();
            adminDTO.ID = txtID.Text;
            adminDTO.NAME = txtName.Text;
            adminDTO.USERNAME = txtUsername.Text;
            adminDTO.PASSWORD = txtPass.Text;
            

            if (adminBUS.addAdmin(adminDTO))
            {
                AdminBUS.AdminList.Rows.Add(adminDTO.ID, adminDTO.NAME, adminDTO.USERNAME, adminDTO.PASSWORD);
                adminDataGridView.DataSource = AdminBUS.AdminList;
                id_focus = true;
                reset_form();
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (id_focus)
            {
                adminBUS.removeAdmin(txtID.Text);
                DataRow[] rowsToDelete = AdminBUS.AdminList.Select("ID = '" + txtID.Text + "'");
                AdminBUS.AdminList.Rows.Remove(rowsToDelete[0]);
                adminDataGridView.DataSource = AdminBUS.AdminList;
                reset_form();
            }

            else
                MessageBox.Show("Đối tượng này chưa được lưu vào danh sách nên không thể xóa");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset_form();
        }
    }
}
