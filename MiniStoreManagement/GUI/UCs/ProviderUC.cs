using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.FormSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class ProviderUC : UserControl
    {
        private ProviderBUS providerBUS = new ProviderBUS();
        private bool id_focus = false;
        private string _state = "1";
        public ProviderUC()
        {
            InitializeComponent();
        }
        public ProviderUC(string i)
        {
            InitializeComponent();

            _state = i;
            txtSĐT.Enabled = false;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;

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

        private void ProviderUC_Load(object sender, EventArgs e)
        {
            if (ProviderBUS.ProviderList == null)
                providerBUS.getProvider();
            new_id();

            dataGridView1.DataSource = show_data();
            dataGridView1.Columns["STATE"].Visible = false;
        }
        
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            reset_form();
            if (show_data().Rows.Count == 0)
                return;
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form();
                return;
            }
            id_focus = true;

            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSĐT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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

            ProviderDTO providerDTO = new ProviderDTO();
            providerDTO.Id = txtID.Text;
            providerDTO.Name = txtName.Text;
            providerDTO.Address = txtAddress.Text;
            providerDTO.Cell = txtSĐT.Text;
            providerDTO.Email = txtEmail.Text;

            if (providerBUS.addProvider(providerDTO))
            {
                ProviderBUS.ProviderList.Rows.Add(providerDTO.Id, providerDTO.Name, providerDTO.Cell, providerDTO.Address, providerDTO.Email, providerDTO.State);
                showdata();
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
                    if (providerBUS.removeProvider(txtID.Text))
                    {
                        DataRow[] rowsToDelete = ProviderBUS.ProviderList.Select("ID = '" + txtID.Text + "'");
                        ProviderBUS.ProviderList.Rows.Remove(rowsToDelete[0]);
                        dataGridView1.DataSource = show_data();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                        MessageBox.Show("Không thể xóa đối tượng!");
                }
            }
            else
                reset_form();
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
                DataRow rowToUpdate = ProviderBUS.ProviderList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                ProviderDTO providerDTO = new ProviderDTO();
                if (rowToUpdate != null)
                {
                    providerDTO.Id = txtID.Text;
                    providerDTO.Name = rowToUpdate[1].ToString();
                    providerDTO.Cell = rowToUpdate[2].ToString();
                    providerDTO.Address = rowToUpdate[3].ToString();
                    providerDTO.Email = rowToUpdate[4].ToString();
                    providerDTO.State = "1";
                    if (providerBUS.updateProvider(providerDTO))
                    {
                        rowToUpdate[5] = "1";
                        showdata();
                        reset_form();

                        if (_state == "1")
                            MessageBox.Show("Đã xóa");
                        else
                            MessageBox.Show("Đã khôi phục");
                    }
                    else
                        MessageBox.Show("không thể làm theo yêu cầu");
                }
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
                ProviderDTO providerDTO = new ProviderDTO();
                providerDTO.Id = txtID.Text;
                providerDTO.Name = txtName.Text;
                providerDTO.Address = txtAddress.Text;
                providerDTO.Cell = txtSĐT.Text;
                providerDTO.Email = txtEmail.Text;

                if (providerBUS.updateProvider(providerDTO))
                {
                    DataRow rowToUpdate = ProviderBUS.ProviderList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = providerDTO.Name;
                        rowToUpdate[2] = providerDTO.Cell;
                        rowToUpdate[3] = providerDTO.Address;
                        rowToUpdate[4] = providerDTO.Email;

                        dataGridView1.DataSource = show_data();
                        MessageBox.Show("Đã sửa");
                    }
                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = show_data().DefaultView;
            string txt = txtSearch.Text;

            if (txtSearch.Text == "")
            {
                dv.RowFilter = "ID LIKE '%1%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR CELL LIKE '%{txt}%' OR ADDRESS LIKE '%{txt}%' OR EMAIL LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void new_id()
        {
            if (ProviderBUS.ProviderList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(ProviderBUS.ProviderList.Rows[ProviderBUS.ProviderList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
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
            txtAddress.ResetText();
            txtEmail.ResetText();
            txtSearch.ResetText();
            dataGridView1.ClearSelection();
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

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        public void showdata() // này là để ấy từ thùng rác dề form chính
        {
            dataGridView1.DataSource = show_data();
        }

        private DataTable show_data()
        {
            if (_state == "0")
            {
                var filteredRows1 = ProviderBUS.ProviderList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : ProviderBUS.ProviderList.Clone();
            }

            var filteredRows = ProviderBUS.ProviderList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : ProviderBUS.ProviderList.Clone();
        }
    }
}
