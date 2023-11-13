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

namespace MiniStoreManagement.GUI.items
{
    public partial class AddPurchaseDetailInvoice : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        private PurchaseInvoiceBUS purchaseInvoiceBUS = new PurchaseInvoiceBUS();
        private PurchaseInvoiceDetailBUS purchaseInvoiceDetailBUS = new PurchaseInvoiceDetailBUS();
        private string invoice_id;
        private DataTable dataShow;
        public AddPurchaseDetailInvoice(string id)
        {
            InitializeComponent();
            invoice_id = id;
            LoadDetail();
        }

        public AddPurchaseDetailInvoice()
        {
            InitializeComponent();
            LoadDetail();
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
        }

        private void LoadDetail()
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();
            if (PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList == null)
            {
                purchaseInvoiceDetailBUS.getInvoiceDetail();
            }
            dataShow = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Clone();

            foreach (DataRow row in ProductBUS.ProductList.Rows)
            {
                cbbID_product.Items.Add(row["ID"].ToString());
            }
            foreach (DataRow row in PurchaseInvoiceBUS.PurchaseInvoiceList.Rows)
            {
                cbbID_invoice.Items.Add(row["ID"].ToString());
            }

            cbbID_invoice.SelectedItem = invoice_id;
        }

        private void cbbID_invoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbID_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID_product.SelectedItem == null)
            {
                return;
            }
            int id_product = int.Parse(cbbID_product.SelectedItem.ToString());
            DataRow find = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable().FirstOrDefault(row => row.Field<int>("PRODUCT_ID") == id_product && row.Field<int>("INVOICE_ID") == int.Parse(invoice_id));
            if (find != null)
            {
                numericUpDown1.Value = find.Field<int>("QUANTITY");
            }
            DataRow find_price = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == id_product);
            txtPrice.Text = find_price.Field<decimal>("PRICE").ToString("#,##0");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (is_exists())
            {
                MessageBox.Show("Sản phẩm này đã tồn tại trong hóa đơn");
                return;
            }
            if (!check())
                return;

            InvoiceDetailDTO invoiceDetailDTO = new InvoiceDetailDTO();
            invoiceDetailDTO.InvoiceId = invoice_id;
            invoiceDetailDTO.ProductId = cbbID_product.SelectedItem.ToString();
            invoiceDetailDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            invoiceDetailDTO.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));

            if (purchaseInvoiceDetailBUS.addInvoiceDetail(invoiceDetailDTO))
            {
                PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Rows.Add(invoiceDetailDTO.InvoiceId, invoiceDetailDTO.ProductId, invoiceDetailDTO.Quantity, invoiceDetailDTO.Price);
                show_data();
            }
            else
            {
                MessageBox.Show("Lỗi không thể thêm thành công");
                return;
            }
        }

        private bool check()
        {
            if (cbbID_product.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống id sản phẩm");
                cbbID_product.Focus();
                return false;
            }
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Không được để số lượng bằng 0");
                numericUpDown1.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!is_exists())
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể sửa");
                return;
            }
            if (!check())
                return;

            InvoiceDetailDTO invoiceDetailDTO = new InvoiceDetailDTO();
            invoiceDetailDTO.InvoiceId = invoice_id;
            invoiceDetailDTO.ProductId = cbbID_product.SelectedItem.ToString();
            invoiceDetailDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            invoiceDetailDTO.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));

            if (purchaseInvoiceDetailBUS.updateInvoiceDetail(invoiceDetailDTO))
            {
                DataRow rowToUpdate = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable().FirstOrDefault
                    (row => row.Field<string>("INVOICE_ID") == invoiceDetailDTO.InvoiceId && row.Field<string>("PRODUCT_ID") == invoiceDetailDTO.ProductId);

                if (rowToUpdate != null)
                {
                    rowToUpdate[3] = invoiceDetailDTO.Quantity;
                    rowToUpdate[4] = invoiceDetailDTO.Price;
                }
                dataGridView1.DataSource = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList;
            }
            else
                MessageBox.Show("không thể sửa theo yêu cầu");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!is_exists())
            {
                string id_product = cbbID_product.SelectedItem.ToString();
                purchaseInvoiceDetailBUS.removeInvoiceDetail(invoice_id, id_product);
                DataRow[] rowsToDelete = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("PRODUCT_ID = '" + id_product + "' AND INVOICE_ID = '" + invoice_id + "'");
                PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Rows.Remove(rowsToDelete[0]);
                dataGridView1.DataSource = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList;
            }
            else
                MessageBox.Show("Đối tượng này chưa được lưu vào danh sách nên không thể xóa");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            cbbID_product.SelectedItem = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataShow.Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có dữ liệu");
                return;
            }

            DataRow rowToUpdate = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == int.Parse(invoice_id));

            decimal sum = dataShow.AsEnumerable().Sum(row => row.Field<decimal>("PRICE") * row.Field<int>("QUANTITY"));

            PurchaseInvoiceDTO purchaseInvoiceDTO = new PurchaseInvoiceDTO();
            purchaseInvoiceDTO.Id = invoice_id;
            purchaseInvoiceDTO.EmployeeId = rowToUpdate[1].ToString();
            purchaseInvoiceDTO.Date = DateTime.Parse(rowToUpdate[2].ToString());
            purchaseInvoiceDTO.TotalPayment = sum;
            purchaseInvoiceDTO.ProviderId = rowToUpdate[4].ToString();
            purchaseInvoiceDTO.State = "1";

            if (purchaseInvoiceBUS.updateInvoice(purchaseInvoiceDTO))
            {
                rowToUpdate[3] = sum;
                rowToUpdate[5] = "1";

                DataRow[] filteredRows = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("INVOICE_ID = " + invoice_id);
                foreach (DataRow row in filteredRows)
                {
                    DataRow rowProduct = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(_row => _row.Field<int>("ID") == row.Field<int>("PRODUCT_ID"));
                    
                    ProductDTO productDTO = new ProductDTO();
                    productDTO.Id = rowProduct.Field<string>("ID");
                    productDTO.Name = rowProduct.Field<string>("NAME");
                    productDTO.CategoryId = rowProduct.Field<string>("CATEGORY_ID");
                    productDTO.PromotionId = rowProduct.Field<string>("PROMOTION_ID");
                    productDTO.ProviderId = rowProduct.Field<string>("PROVIDER_ID");
                    productDTO.Price = row.Field<decimal>("PRICE") * 16 / 10; /////// này nè
                    productDTO.Quantity = rowProduct.Field<int>("QUANTITY") + row.Field<int>("QUANTITY");
                    productDTO.Exp = rowProduct.Field<DateTime>("EXP"); ////HMMMMMMMMMMMMM
                    productDTO.Img = rowProduct.Field<string>("IMG");

                    if (productBUS.updateProduct(productDTO))
                    {
                        rowProduct[5] = productDTO.Price;
                        rowProduct[6] = productDTO.Quantity;
                    }
                }

            }


            pnlControl.Visible = false;
        }
        private void show_data()
        {
            DataRow[] filteredRows = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("INVOICE_ID = " + invoice_id);
            dataShow.Clear();
            foreach (DataRow row in filteredRows)
            {
                dataShow.ImportRow(row);
            }
            dataGridView1.DataSource = dataShow;
        }

        private bool is_exists()
        {
            DataRow[] check = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("PRODUCT_ID = " + cbbID_product.SelectedItem.ToString() + " AND INVOICE_ID = " + invoice_id);
            if (check.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
