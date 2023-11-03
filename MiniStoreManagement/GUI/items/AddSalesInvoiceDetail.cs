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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement.GUI.items
{
    public partial class AddSalesInvoiceDetail : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();

        private bool id_focus = false;
        public AddSalesInvoiceDetail(string id)
        {
            InitializeComponent();
            LoadDetail(id);
        }

        private void LoadDetail(string id)
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();
            if (SalesInvoiceDetailBUS.SalesInvoiceDetailList == null)
            {
                salesInvoiceDetailBUS.getInvoiceDetail();
            }

            foreach (DataRow row in ProductBUS.ProductList.Rows)
            {
                cbbID_product.Items.Add(row["ID"].ToString());
            }
            foreach (DataRow row in SalesInvoiceBUS.SalesInvoiceList.Rows)
            {
                cbbID_invoice.Items.Add(row["ID"].ToString());
            }

            cbbID_invoice.SelectedItem = id;
        }

        private void cbbID_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_invoice = int.Parse(cbbID_invoice.SelectedItem.ToString());
            int id_product = int.Parse(cbbID_product.SelectedItem.ToString());
            DataRow find = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().FirstOrDefault(row => row.Field<int>("PRODUCT_ID") == id_product && row.Field<int>("INVOICE_ID") == id_invoice);
            if (find != null)
            {
                numericUpDown1.Value = find.Field<int>("QUANTITY");
            }
            DataRow find_price = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == id_product);
            txtPrice.Text = (numericUpDown1.Value * find_price.Field<decimal>("PRICE")).ToString("#,##0");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DataRow find_price = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == int.Parse(cbbID_product.SelectedItem.ToString()));
            txtPrice.Text = (numericUpDown1.Value * find_price.Field<decimal>("PRICE")).ToString("#,##0");
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

            SalesInvoiceDetailDTO salesInvoiceDetailDTO = new SalesInvoiceDetailDTO();
            salesInvoiceDetailDTO.InvoiceId = int.Parse(cbbID_invoice.SelectedItem.ToString());
            salesInvoiceDetailDTO.ProductId = int.Parse(cbbID_product.SelectedItem.ToString());
            salesInvoiceDetailDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());

            if (salesInvoiceDetailBUS.addInvoiceDetail(salesInvoiceDetailDTO))
            {
                SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Add(salesInvoiceDetailDTO.InvoiceId, salesInvoiceDetailDTO.ProductId, salesInvoiceDetailDTO.Quantity);
                dataGridView1.DataSource = SalesInvoiceDetailBUS.SalesInvoiceDetailList;
                id_focus = true;
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
    }
}
