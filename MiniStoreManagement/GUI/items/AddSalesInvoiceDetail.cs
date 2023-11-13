using MiniStoreManagement.BUS;
using MiniStoreManagement.DAO;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.UCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MiniStoreManagement.GUI.items
{
    public partial class AddSalesInvoiceDetail : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        private SalesInvoiceBUS salesInvoiceBUS = new SalesInvoiceBUS();
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();
        private string invoice_id;
        private DataTable dataShow;

        //private bool id_focus = false;
        public AddSalesInvoiceDetail(string id)
        {
            InitializeComponent();
            invoice_id = id;
            LoadDetail();
        }
        public AddSalesInvoiceDetail()
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
            if (SalesInvoiceDetailBUS.SalesInvoiceDetailList == null)
            {
                salesInvoiceDetailBUS.getInvoiceDetail();
            }
            dataShow = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Clone();

            foreach (DataRow row in ProductBUS.ProductList.Rows)
            {
                cbbID_product.Items.Add(row["ID"].ToString());
            }
            foreach (DataRow row in SalesInvoiceBUS.SalesInvoiceList.Rows)
            {
                cbbID_invoice.Items.Add(row["ID"].ToString());
            }

            cbbID_invoice.SelectedItem = invoice_id;
        }

        private void cbbID_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbID_product.SelectedItem == null)
            {
                return;
            }
            string id_product = cbbID_product.SelectedItem.ToString();
            DataRow find = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().FirstOrDefault(row => row.Field<string>("PRODUCT_ID") == id_product && row.Field<string>("INVOICE_ID") == invoice_id);
            if (find != null)
            {
                numericUpDown1.Value = find.Field<int>("QUANTITY");
            }
            DataRow find_price = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == id_product);
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

            if (salesInvoiceDetailBUS.addInvoiceDetail(invoiceDetailDTO))
            {
                SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Add(invoiceDetailDTO.InvoiceId, invoiceDetailDTO.ProductId, invoiceDetailDTO.Quantity, invoiceDetailDTO.Price);
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

            if (salesInvoiceDetailBUS.updateInvoiceDetail(invoiceDetailDTO))
            {
                DataRow rowToUpdate = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().FirstOrDefault
                    (row => row.Field<string>("INVOICE_ID") == invoiceDetailDTO.InvoiceId && row.Field<string>("PRODUCT_ID") == invoiceDetailDTO.ProductId);

                if (rowToUpdate != null)
                {
                    rowToUpdate[3] = invoiceDetailDTO.Quantity;
                    rowToUpdate[4] = invoiceDetailDTO.Price;
                }
                dataGridView1.DataSource = SalesInvoiceDetailBUS.SalesInvoiceDetailList;
            }
            else
                MessageBox.Show("không thể sửa theo yêu cầu");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!is_exists())
            {
                string id_product = cbbID_product.SelectedItem.ToString();
                salesInvoiceDetailBUS.removeInvoiceDetail(invoice_id, id_product);
                DataRow[] rowsToDelete = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("PRODUCT_ID = '" + id_product + "' AND INVOICE_ID = '" + invoice_id + "'");
                SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Remove(rowsToDelete[0]);
                dataGridView1.DataSource = SalesInvoiceDetailBUS.SalesInvoiceDetailList;
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
            if(dataShow.Rows.Count == 0) {
                MessageBox.Show("Đơn hàng chưa có dữ liệu");
                return;
            }
            DataRow rowToUpdate = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == invoice_id);
            SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO();
            if (rowToUpdate != null)
            {
                decimal sum = dataShow.AsEnumerable().Sum(row => row.Field<decimal>("PRICE") * row.Field<int>("QUANTITY"));
                salesInvoiceDTO.Id = invoice_id;
                salesInvoiceDTO.EmployeeId = rowToUpdate[1].ToString();
                salesInvoiceDTO.Date = DateTime.Parse(rowToUpdate[2].ToString());
                salesInvoiceDTO.TotalPayment = sum;
                salesInvoiceDTO.ConsumerId = rowToUpdate[4].ToString();
                if (!string.IsNullOrWhiteSpace(rowToUpdate[5].ToString()))
                {
                    salesInvoiceDTO.VoucherId = rowToUpdate[5].ToString();
                    //DataRow _row = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<int>("ID") == salesInvoiceDTO.VoucherId);
                    //salesInvoiceDTO.TotalPayment = sum - 1;
                }
                else
                    salesInvoiceDTO.VoucherId = null;
                salesInvoiceDTO.State = "1";
                rowToUpdate[3] = sum;
                rowToUpdate[6] = "1";
                salesInvoiceBUS.updateInvoice(salesInvoiceDTO);
            }
            pnlControl.Visible = false;
        }
        private void show_data()
        {
            DataRow[] filteredRows = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("INVOICE_ID = " + invoice_id);
            dataShow.Clear();
            foreach (DataRow row in filteredRows)
            {
                dataShow.ImportRow(row);
            }
            dataGridView1.DataSource = dataShow;
        }

        private bool is_exists()
        {
            if(SalesInvoiceDetailBUS.SalesInvoiceDetailList == null)
            {
                return true;
            }
            DataRow[] check = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("PRODUCT_ID = " + cbbID_product.SelectedItem.ToString() + " AND INVOICE_ID = " + invoice_id);
            if(check.Length > 0 )
            {
                return true;
            }
            return false;
        }
    }
}
