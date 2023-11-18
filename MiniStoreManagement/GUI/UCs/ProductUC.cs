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
using MiniStoreManagement.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class ProductUC : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        private ProviderBUS providerBUS = new ProviderBUS();
        private CategoryBUS categoryBUS = new CategoryBUS();
        private PromotionBUS promotionBUS = new PromotionBUS();

        private string fileName;
        private bool id_focus = false;
        private string _state = "1";
        private string _cat = null;
        public ProductUC()
        {
            InitializeComponent();
        }
        // này là vô theo phân loại
        public ProductUC(int i)
        {
            InitializeComponent();
            _cat = i.ToString();
        }

        // Này là để vô cái xóa
        public ProductUC(string i)
        {
            InitializeComponent();

            _state = i;
            cbbID_category.Enabled = false;
            txtName.Enabled = false;
            cbbID_promotion.Enabled = false;
            cbbID_provider.Enabled = false;
            dateTimePicker1.Enabled = false;

            btnAdd.Visible = false;
            BtnUpdate.Visible = false;
            btnNew.Text = "Xóa";
            btnDel.Text = "Hoàn";
            make_center();
        }
        public void make_center()
        {
            int spacing = 45; // Khoảng cách giữa hai nút
            int panelHeight = panel2.Height;
            int buttonHeight = btnAdd.Height;

            // Tính toán vị trí để đặt nút ở giữa chiều dọc của Panel
            int yPositionButton1 = (panelHeight - buttonHeight * 2 - spacing) / 2;
            int yPositionButton2 = yPositionButton1 + buttonHeight + spacing;

            btnNew.Location = new System.Drawing.Point(btnAdd.Location.X, yPositionButton1);
            btnDel.Location = new System.Drawing.Point(btnDel.Location.X, yPositionButton2);
        }
        private void ProductUC_Load(object sender, EventArgs e)
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();
            if (ProviderBUS.ProviderList == null)
                providerBUS.getProvider();
            if(CategoryBUS.CategoryList == null)
                categoryBUS.getCategory();
            if(PromotionBUS.PromotionList == null)
                promotionBUS.getPromotion();

            new_id();

            dataGridView1.DataSource = show_data();
            dataGridView1.Columns["STATE"].Visible = false;

            foreach (DataRow row in ProviderBUS.ProviderList.Rows)
                cbbID_provider.Items.Add(row["ID"].ToString());
            foreach (DataRow row in CategoryBUS.CategoryList.Rows)
                cbbID_category.Items.Add(row["ID"].ToString());
            foreach (DataRow row in PromotionBUS.PromotionList.Rows)
                cbbID_promotion.Items.Add(row["ID"].ToString());
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Img Files (*.jpg;*.png;*.gif;*.svg;)|*.jpg;*.png;*.gif;*.svg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = Path.GetFileName(ofd.FileName);
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "EXP")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form();
                return;
            }
            id_focus = true;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            txtPrice.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            cbbID_category.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbbID_promotion.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbbID_provider.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());

            if (dataGridView1.CurrentRow.Cells[8].Value.ToString() != "")
            {
                pictureBox1.Image = new Bitmap("..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() +"//"+ dataGridView1.CurrentRow.Cells[8].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Image = null;
                fileName = null;
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

            ProductDTO productDTO = new ProductDTO();
            productDTO.Id = txtID.Text;
            productDTO.Name = txtName.Text;
            productDTO.ProviderId = cbbID_provider.SelectedItem.ToString();
            productDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            productDTO.Price = int.Parse(txtPrice.Text);
            productDTO.Exp = dateTimePicker1.Value;

            if (cbbID_category.SelectedIndex != -1)
                productDTO.CategoryId = cbbID_category.SelectedItem.ToString();
            else
                productDTO.CategoryId = null;

            if (cbbID_promotion.SelectedIndex != -1)
                productDTO.PromotionId = cbbID_promotion.SelectedItem.ToString();
            else
                productDTO.PromotionId = null;

            if (fileName != null && fileName != "")
                productDTO.Img = fileName;
            else
                productDTO.Img = null;

            if (productBUS.addProduct(productDTO))
            {
                ProductBUS.ProductList.Rows.Add(productDTO.Id, productDTO.Name, productDTO.CategoryId, productDTO.PromotionId, productDTO.ProviderId,
                                                productDTO.Price, productDTO.Quantity, productDTO.Exp, productDTO.Img, productDTO.State);

                dataGridView1.DataSource = show_data();
                dataGridView1.Columns["STATE"].Visible = false;

                SaveImg();
                id_focus = true;
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
        }

        private void reset_form()
        {
            id_focus = false;
            new_id();
            txtName.ResetText();
            txtPrice.ResetText();
            txtPrice.Text = "0";
            txtSearch.ResetText();
            numericUpDown1.Value = 0;
            cbbID_category.SelectedItem = null;
            cbbID_promotion.SelectedItem = null;
            cbbID_provider.SelectedItem = null;
            pictureBox1.Image = null;
            fileName = null;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = " ";
            dataGridView1.ClearSelection();
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
                    productBUS.removeProduct(txtID.Text);
                    DataRow[] rowsToDelete = ProductBUS.ProductList.Select("ID = '" + txtID.Text + "'");
                    ProductBUS.ProductList.Rows.Remove(rowsToDelete[0]);
                    dataGridView1.DataSource = show_data();
                    dataGridView1.Columns["STATE"].Visible = false;
                }
            }
            else
                reset_form();
        }

        private bool check()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Không được để trống tên");
                txtName.Focus();
                return false;
            }
            if (cbbID_provider.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống id nguồn cung");
                cbbID_provider.Focus();
                return false;
            }

            if (dateTimePicker1.CustomFormat == " ")
            {
                MessageBox.Show("Không được để trống HSD");
                dateTimePicker1.Focus();
                return false;
            }

            if (DateTime.Now > dateTimePicker1.Value)
            {
                MessageBox.Show("Món này đã hết hạn sử dụng");
                dateTimePicker1.Focus();
                return false;
            }

            return true;
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
                DataRow rowToUpdate = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                ProductDTO productDTO = new ProductDTO();
                if (rowToUpdate != null)
                {
                    productDTO.Id = txtID.Text;
                    productDTO.Name = rowToUpdate[1].ToString();

                    if (string.IsNullOrEmpty(rowToUpdate[2].ToString()))
                        productDTO.CategoryId = null;
                    else
                        productDTO.CategoryId = rowToUpdate[2].ToString();

                    if (string.IsNullOrEmpty(rowToUpdate[3].ToString()))
                        productDTO.PromotionId = null;
                    else
                        productDTO.PromotionId = rowToUpdate[3].ToString();

                    productDTO.ProviderId = rowToUpdate[4].ToString();
                    productDTO.Price = (decimal)rowToUpdate[5];
                    productDTO.Quantity = (int)rowToUpdate[6];
                    productDTO.Exp = DateTime.Parse(rowToUpdate[7].ToString());
                    productDTO.Img = rowToUpdate[8].ToString();
                    productDTO.State = "1";
                    rowToUpdate[9] = "1";
                    productBUS.updateProduct(productDTO);

                    dataGridView1.DataSource = show_data();
                    dataGridView1.Columns["STATE"].Visible = false;

                    if (_state == "1")
                        MessageBox.Show("Đã xóa");
                    else
                        MessageBox.Show("Đã khôi phục");
                }
                else
                    MessageBox.Show("không thể làm theo yêu cầu");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = show_data().DefaultView;
            string txt = txtSearch.Text;

            if (txtSearch.Text == "")
            {
                dv.RowFilter = "GENDER LIKE '%N%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR CATEGORY_ID LIKE '%{txt}%' OR PROMOTION_ID LIKE '%{txt}%' OR PROVIDER_ID LIKE '%{txt}%' "
                         + $"OR CONVERT(PRICE, 'System.String') LIKE '%{txt}%' OR CONVERT(QUANTITY, 'System.String') LIKE '%{txt}%' ";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void LoadData(string query)
        {
            DataView dv = ProductBUS.ProductList.DefaultView;
            dv.RowFilter = query;
            dataGridView1.DataSource = dv.ToTable();
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    TimKiemProduct timkiem = new TimKiemProduct();
        //    timkiem.temp = new TimKiemProduct.truyenDuLieu(LoadData);
        //    timkiem.Show();
        //}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.CustomFormat == " ")
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void new_id()
        {
            if (ProductBUS.ProductList.Rows.Count > 0)
            {
                txtID.Text = (int.Parse(ProductBUS.ProductList.Rows[ProductBUS.ProductList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID.Text = "100000";
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
                ProductDTO productDTO = new ProductDTO();
                productDTO.Id = txtID.Text;
                productDTO.Name = txtName.Text;
                productDTO.ProviderId = cbbID_provider.Text;
                productDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
                productDTO.Price = int.Parse(txtPrice.Text);
                productDTO.Exp = dateTimePicker1.Value;

                if (cbbID_category.SelectedIndex != -1)
                    productDTO.CategoryId = cbbID_category.Text;
                else
                    productDTO.CategoryId = null;

                if (cbbID_promotion.SelectedIndex != -1)
                    productDTO.PromotionId = cbbID_promotion.Text;
                else
                    productDTO.PromotionId = null;

                if (fileName != null && fileName != "")
                    productDTO.Img = fileName;
                else
                    productDTO.Img = null;

                if (productBUS.updateProduct(productDTO))
                {
                    DataRow rowToUpdate = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);

                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = productDTO.Name;
                        rowToUpdate[2] = productDTO.CategoryId;
                        rowToUpdate[3] = productDTO.PromotionId;
                        rowToUpdate[4] = productDTO.ProviderId;
                        rowToUpdate[5] = productDTO.Price;
                        rowToUpdate[6] = productDTO.Quantity;
                        rowToUpdate[7] = productDTO.Exp;
                        rowToUpdate[9] = productDTO.State;
                        if (productDTO.Img != null)
                            rowToUpdate[8] = productDTO.Img;

                        dataGridView1.DataSource = show_data();
                        dataGridView1.Columns["STATE"].Visible = false;

                        SaveImg();
                        MessageBox.Show("Đã sửa");
                    }
                }
                else
                    MessageBox.Show("không thể sửa theo yêu cầu");
            }
        }

        private void SaveImg()
        {
            if (pictureBox1.Image != null && fileName != null)
            {
                string filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//pro" + txtID.Text;
                pictureBox1.Image.Save(filePath);
            }
        }
        public void showdata()
        {
            dataGridView1.DataSource = show_data();
            dataGridView1.Columns["STATE"].Visible = false;
        }
        private DataTable show_data()
        {
            if (_state == "0" && _cat == null)
            {
                var filteredRows1 = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : ProductBUS.ProductList.Clone();
            }
            else if (_state == "1" && _cat == null)
            {
                var filteredRows2 = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows2.Any() ? filteredRows2.CopyToDataTable() : ProductBUS.ProductList.Clone();
            }
            else if (_state == "0")
            {
                var filteredRows3 = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "1" && row.Field<string>("CATEGORY_ID") == _cat);
                return filteredRows3.Any() ? filteredRows3.CopyToDataTable() : ProductBUS.ProductList.Clone();
            }
            var filteredRows4 = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0" && row.Field<string>("CATEGORY_ID") == _cat);
            return filteredRows4.Any() ? filteredRows4.CopyToDataTable() : ProductBUS.ProductList.Clone();
        }
    }
}
