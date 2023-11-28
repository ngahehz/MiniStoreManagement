using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
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
using System.Xml.Linq;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class CategoryUC : UserControl
    {
        private CategoryBUS categoryBUS = new CategoryBUS();
        private ProductBUS productBUS = new ProductBUS();
        private bool id_focus = false;
        private string _state = "1";

        public CategoryUC()
        {
            InitializeComponent();
        }

        public CategoryUC(string i)
        {
            InitializeComponent();

            _state = i;
            groupBox1.Visible = false;
            BtnUpdate.Visible = false;
            btnAdd.Visible = false;
            btnNew.Text = "Xóa";
            btnDel.Text = "Hoàn";
            make_center();
            txtName_category.Enabled = false;
        }

        public void make_center()
        {
            int spacing = 45; // Khoảng cách giữa hai nút
            int panelHeight = panel2.Height;
            int buttonHeight = btnAdd.Height;

            // Tính toán vị trí để đặt nút ở giữa chiều dọc của Panel
            int yPositionButton1 = (panelHeight - buttonHeight * 2 - spacing) / 2;
            int yPositionButton2 = yPositionButton1 + buttonHeight + spacing;

            // Đặt vị trí của nút 1
            btnNew.Location = new Point(btnAdd.Location.X, yPositionButton1);

            // Đặt vị trí của nút 2
            btnDel.Location = new Point(btnDel.Location.X, yPositionButton2);
        }

        private void CategoryUC_Load(object sender, EventArgs e)
        {
            if (CategoryBUS.CategoryList == null)
                categoryBUS.getCategory();
            if(ProductBUS.ProductList == null)
                productBUS.getProduct();

            if(show_data_pro() != null)
                foreach (DataRow row in show_data_pro().Rows)
                    cbbID_product.Items.Add(row["ID"].ToString());

            new_id();

            showdata();
            dataGridView1.Columns["STATE"].Visible = false;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            reset_form();
            if (show_data().Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
                return;

            id_focus = true;

            txtID_category.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName_category.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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

            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Id = txtID_category.Text;
            categoryDTO.Name = txtName_category.Text;

            if (categoryBUS.addCategory(categoryDTO))
            {
                CategoryBUS.CategoryList.Rows.Add(categoryDTO.Id, categoryDTO.Name, categoryDTO.State);
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
                    if (categoryBUS.removeCategory(txtID_category.Text))
                    {
                        DataRow[] rowsToDelete = CategoryBUS.CategoryList.Select("ID = '" + txtID_category.Text + "'");
                        CategoryBUS.CategoryList.Rows.Remove(rowsToDelete[0]);
                        showdata();
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
                if(_state == "1")
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
                DataRow rowToUpdate = CategoryBUS.CategoryList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID_category.Text);
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.Id = txtID_category.Text;
                categoryDTO.Name = rowToUpdate[1].ToString();
                categoryDTO.State = _state;
                if( categoryBUS.updateCategory(categoryDTO))
                {
                    rowToUpdate[2] = _state;
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
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.Id = txtID_category.Text;
                categoryDTO.Name = txtName_category.Text;

                if (categoryBUS.updateCategory(categoryDTO))
                {
                    DataRow rowToUpdate = CategoryBUS.CategoryList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID_category.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = categoryDTO.Name;
                        showdata();
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

            dv.RowFilter = $"ID LIKE '%{txt}%' OR NAME LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void new_id()
        {
            if (CategoryBUS.CategoryList.Rows.Count > 0)
            {
                txtID_category.Text = (int.Parse(CategoryBUS.CategoryList.Rows[CategoryBUS.CategoryList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID_category.Text = "100";
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtName_category.ResetText();
            txtName_product.ResetText();
            cbbID_product.SelectedItem = null;
            txtSearch.ResetText();
            dataGridView1.ClearSelection();
        }

        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txtName_category.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtName_category.Focus();
                return false;
            }
            return true;
        }

        private void cbbID_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow find_row = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == cbbID_product.SelectedItem.ToString());
            txtName_product.Text = find_row[1].ToString();
        }

        private void btnSave_product_Click(object sender, EventArgs e)
        {
            if (cbbID_product.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn id sản phẩm");
            }

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataRow rowToUpdate = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == cbbID_product.Text);
                ProductDTO productDTO = new ProductDTO();
                if (rowToUpdate != null)
                {
                    productDTO.Id = cbbID_product.Text;
                    productDTO.Name = rowToUpdate[1].ToString();
                    productDTO.CategoryId = txtID_category.Text;
                    productDTO.PromotionId = rowToUpdate[3].ToString();
                    productDTO.ProviderId = rowToUpdate[4].ToString();
                    productDTO.Price = decimal.Parse(rowToUpdate[5].ToString());
                    productDTO.Quantity = int.Parse(rowToUpdate[6].ToString());
                    productDTO.Img = rowToUpdate[8].ToString();
                    productDTO.State = rowToUpdate[9].ToString();
                    rowToUpdate[2] = productDTO.CategoryId;
                    productBUS.updateProduct(productDTO);
                    MessageBox.Show("Đã thêm phân loại cho sản phẩm " + cbbID_product.Text);
                }
            }
        }

        private DataTable show_data()
        {
            if (_state == "0")
            {
                var filteredRows1 = CategoryBUS.CategoryList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : CategoryBUS.CategoryList.Clone();
            }

            var filteredRows = CategoryBUS.CategoryList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : CategoryBUS.CategoryList.Clone();
        }

        private DataTable show_data_pro()
        {
            var filteredRows = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0" && row.Field<string>("CATEGORY_ID") == null);
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : null;
        }

        public void showdata()
        {
            dataGridView1.DataSource = show_data();
        }
    }
}
