using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.FormSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            btnNew.Location = new Point(btnAdd.Location.X, yPositionButton1);
            btnDel.Location = new Point(btnDel.Location.X, yPositionButton2);
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

            if(show_data(1) != null)
                foreach (DataRow row in show_data(1).Rows)
                    cbbID_provider.Items.Add(row["ID"].ToString());
            if (show_data(2) != null)
                foreach (DataRow row in show_data(2).Rows)
                    cbbID_category.Items.Add(row["ID"].ToString());
            if (show_data(3) != null)
                foreach (DataRow row in show_data(3).Rows)
                    cbbID_promotion.Items.Add(row["ID"].ToString());

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
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbID_category.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbbID_promotion.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbbID_provider.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());

            decimal price = decimal.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            if (cbbID_promotion.SelectedItem != null)
            {
                DataRow row_promotion = PromotionBUS.PromotionList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == cbbID_promotion.SelectedItem.ToString());
                decimal newprice = price * (decimal)(1 - (double)row_promotion[2]);
                txtPrice.Text = newprice.ToString("#,##0");
                lbPrice.Text = price.ToString("#,##0");
                lbPrice.Visible = true;
            }
            else
            {
                txtPrice.Text = price.ToString("#,##0");
            }

            if (!string.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[7].Value.ToString()))
            {
                pictureBox1.Image = new Bitmap("..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() +"//"+ dataGridView1.CurrentRow.Cells[7].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackgroundImage = null;
                //fileName = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                fileName = Path.GetExtension(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            }
            else
            {
                pictureBox1.Image = null;
                fileName = null;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Img Files (*.jpg;*.png;*.gif;*.svg;)|*.jpg;*.png;*.gif;*.svg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = Path.GetExtension(ofd.FileName);
                //fileName = Path.GetFileName(ofd.FileName);
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BackgroundImage = null;
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
            //productDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            //productDTO.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));
            productDTO.Quantity = 0;
            productDTO.Price = 0;

            if (cbbID_category.SelectedIndex != -1)
                productDTO.CategoryId = cbbID_category.SelectedItem.ToString();
            else
                productDTO.CategoryId = null;

            if (cbbID_promotion.SelectedIndex != -1)
                productDTO.PromotionId = cbbID_promotion.SelectedItem.ToString();
            else
                productDTO.PromotionId = null;

            if (!string.IsNullOrEmpty(fileName))
                productDTO.Img = "pro" + txtID.Text + fileName;
            else
                productDTO.Img = null;

            if (productBUS.addProduct(productDTO))
            {
                ProductBUS.ProductList.Rows.Add(productDTO.Id, productDTO.Name, productDTO.CategoryId, productDTO.PromotionId, productDTO.ProviderId,
                                                productDTO.Price, productDTO.Quantity, productDTO.Img, productDTO.State);
                showdata();
                SaveImg();
                id_focus = true;
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Lỗi không thể thêm thành công");
        }

        private void btnNew_Click(object sender, EventArgs e) // del hoặc new
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
                    if (productBUS.removeProduct(txtID.Text))
                    {
                        DataRow[] rowsToDelete = ProductBUS.ProductList.Select("ID = '" + txtID.Text + "'");
                        if (!string.IsNullOrEmpty(rowsToDelete[5].ToString()))
                        {
                            string filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//" + rowsToDelete[5].ToString();

                            if (File.Exists(filePath))
                                File.Delete(filePath);
                        }

                        ProductBUS.ProductList.Rows.Remove(rowsToDelete[0]);
                        showdata();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                        MessageBox.Show("Không thể xóa đối tượng!");
                }
            }
            else
            {
                reset_form();
                dataGridView1.ClearSelection();
            }
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
                ProductDTO productDTO = new ProductDTO(rowToUpdate);
                productDTO.State = _state;
                if (productBUS.updateProduct(productDTO))
                {
                    rowToUpdate[8] = _state;
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
                DataRow rowToUpdate = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                ProductDTO productDTO = new ProductDTO(rowToUpdate);
                productDTO.Id = txtID.Text;
                productDTO.Name = txtName.Text;
                productDTO.ProviderId = cbbID_provider.Text;

                if (cbbID_category.SelectedIndex != -1)
                    productDTO.CategoryId = cbbID_category.Text;
                else
                    productDTO.CategoryId = null;

                if (cbbID_promotion.SelectedIndex != -1)
                    productDTO.PromotionId = cbbID_promotion.Text;
                else
                    productDTO.PromotionId = null;

                

                if (productBUS.updateProduct(productDTO))
                {
                    if (rowToUpdate != null)
                    {
                        rowToUpdate[1] = productDTO.Name;
                        rowToUpdate[2] = productDTO.CategoryId;
                        rowToUpdate[3] = productDTO.PromotionId;
                        rowToUpdate[4] = productDTO.ProviderId;
                        rowToUpdate[8] = productDTO.State;
                        //if (productDTO.Img != null)
                        //    rowToUpdate[7] = productDTO.Img;

                        showdata();

                        SaveImg();
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

            dv.RowFilter = $"ID LIKE '%{txt}%' OR NAME LIKE '%{txt}%' OR CATEGORY_ID LIKE '%{txt}%' OR PROMOTION_ID LIKE '%{txt}%' OR PROVIDER_ID LIKE '%{txt}%' "
                         + $"OR CONVERT(PRICE, 'System.String') LIKE '%{txt}%' OR CONVERT(QUANTITY, 'System.String') LIKE '%{txt}%' ";
            dataGridView1.DataSource = dv.ToTable();
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
            lbPrice.Visible = false;
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
            return true;
        }

        private void SaveImg()
        {
            if (pictureBox1.Image != null && fileName != null)
            {
                string filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//pro" + txtID.Text + fileName;

                while (true)
                {
                    try
                    {
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        else
                            break;

                        string fName = Path.GetFileNameWithoutExtension(filePath);
                        filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//" + fName + "1" + fileName;
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Lỗi IO: {ex.Message}");
                        string fName = Path.GetFileNameWithoutExtension(filePath);
                        filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//" + fName + "1" + fileName;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine($"Lỗi truy cập không được ủy quyền: {ex.Message}");
                        string fName = Path.GetFileNameWithoutExtension(filePath);
                        filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//" + fName + "1" + fileName;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi không xác định: {ex.Message}");
                        string fName = Path.GetFileNameWithoutExtension(filePath);
                        filePath = "..//..//Img//Product//" + cbbID_category.SelectedItem.ToString() + "//" + fName + "1" + fileName;
                    }
                }

                //MessageBox.Show(filePath);
                pictureBox1.Image.Save(filePath);

                if (id_focus)
                {
                    DataRow rowToUpdate = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID.Text);
                    ProductDTO productDTO = new ProductDTO(rowToUpdate);

                    if (!string.IsNullOrEmpty(fileName))
                        productDTO.Img = Path.GetFileName(filePath);
                    else
                        productDTO.Img = null;

                    if (productBUS.updateProduct(productDTO))
                    {
                        if (rowToUpdate != null)
                        {
                            if (productDTO.Img != null)
                                rowToUpdate[7] = productDTO.Img;

                            showdata();
                        }
                    }
                }
            }
        }

        private int LoadData(string query)
        {
            DataView dv = show_data().DefaultView;
            dv.RowFilter = query;
            dataGridView1.DataSource = dv.ToTable();
            return dv.ToTable().Rows.Count;
        }

        private void btnsearch_click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TimKiemProduct"] != null)
                return;
            TimKiemProduct timkiem = new TimKiemProduct();
            timkiem.temp = new TimKiemProduct.truyenDuLieu(LoadData);
            timkiem.Show();
        }

        public void showdata()
        {
            dataGridView1.DataSource = show_data();
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

        private DataTable show_data(int number)
        {
            if (number == 1)
            {
                var filteredRows1 = ProviderBUS.ProviderList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : ProviderBUS.ProviderList.Clone();
            }
            if (number == 2)
            {
                var filteredRows2 = CategoryBUS.CategoryList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows2.Any() ? filteredRows2.CopyToDataTable() : CategoryBUS.CategoryList.Clone();
            }
            var filteredRows4 = PromotionBUS.PromotionList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows4.Any() ? filteredRows4.CopyToDataTable() : PromotionBUS.PromotionList.Clone();
        }

        private void btnReset_KM_Click(object sender, EventArgs e)
        {
            cbbID_promotion.SelectedIndex = -1;
        }

        private void btnReset_DM_Click(object sender, EventArgs e)
        {
            cbbID_category.SelectedIndex = -1;
        }

        private void btnReset_IMG_Click(object sender, EventArgs e)
        {
            fileName = null;
            pictureBox1.Image = null;
        }
    }
}
