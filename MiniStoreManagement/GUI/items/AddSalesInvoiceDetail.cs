using MiniStoreManagement.BUS;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.items
{
    public partial class AddSalesInvoiceDetail : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        private StockroomBUS stockroomBUS = new StockroomBUS();
        private PromotionBUS promotionBUS = new PromotionBUS();
        private SalesInvoiceBUS salesInvoiceBUS = new SalesInvoiceBUS();
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();
        private string invoice_id;

        public delegate void truyenDuLieu(decimal txt);
        public delegate void truyenDuLieu2();
        public truyenDuLieu txt_payment;
        public truyenDuLieu showdata;
        public truyenDuLieu2 Enable_cbbVoucher;

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
            pnlControl.Visible = false;
            pnlPrint.Visible = true;
            cbbID_invoice.Enabled = true;
            numericUpDown1.ReadOnly = true;
            cbbID_product.Enabled = false;
        }

        private void LoadDetail()
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();
            if (PromotionBUS.PromotionList == null)
                promotionBUS.getPromotion();
            if (SalesInvoiceDetailBUS.SalesInvoiceDetailList == null)
                salesInvoiceDetailBUS.getInvoiceDetail();
            if (StockroomBUS.StockroomList == null)
                stockroomBUS.getStockroom();

            foreach (DataRow row in show_data(2).Rows)
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
            if (pnlControl.Visible)
            {
                if (cbbID_product.SelectedItem == null)
                {
                    return;
                }
                string id_product = cbbID_product.SelectedItem.ToString();

                DataRow row_product = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == id_product);
                decimal price = (decimal)row_product[5];

                if (!string.IsNullOrWhiteSpace(row_product[3].ToString()))
                {
                    DataRow row_promotion = PromotionBUS.PromotionList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == row_product[3].ToString());
                    txtPrice.Text = (price * (decimal)(1 - (double)row_promotion[2])).ToString("#,##0");
                    //MessageBox.Show(((decimal)(1 - (double)row_promotion[2])).ToString());
                }
                else
                    txtPrice.Text = price.ToString("#,##0");

                DataRow find = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().FirstOrDefault(row => row.Field<string>("PRODUCT_ID") == id_product && row.Field<string>("INVOICE_ID") == invoice_id);
                if (find != null)
                {
                    numericUpDown1.Value = (int)find[2];
                }
                else { numericUpDown1.Value = 0; }
            }
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

            SalesInvoiceDetailDTO invoiceDetailDTO = new SalesInvoiceDetailDTO();
            invoiceDetailDTO.InvoiceId = invoice_id;
            invoiceDetailDTO.ProductId = cbbID_product.SelectedItem.ToString();
            invoiceDetailDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            invoiceDetailDTO.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));

            if (salesInvoiceDetailBUS.addInvoiceDetail(invoiceDetailDTO))
            {
                SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Add(invoiceDetailDTO.InvoiceId, invoiceDetailDTO.ProductId, invoiceDetailDTO.Quantity, invoiceDetailDTO.Price);
                dataGridView1.DataSource = show_data(1);
            }
            else
            {
                MessageBox.Show("Lỗi không thể thêm thành công");
                return;
            }

            decimal sum = show_data(1).AsEnumerable().Sum(row => row.Field<decimal>("PRICE") * row.Field<int>("QUANTITY"));
            txt_payment(sum);
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

            SalesInvoiceDetailDTO invoiceDetailDTO = new SalesInvoiceDetailDTO();
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
                    rowToUpdate[2] = invoiceDetailDTO.Quantity;
                    rowToUpdate[3] = invoiceDetailDTO.Price;
                }
                dataGridView1.DataSource = show_data(1);

                decimal sum = show_data(1).AsEnumerable().Sum(row => row.Field<decimal>("PRICE") * row.Field<int>("QUANTITY"));
                txt_payment(sum);
            }
            else
                MessageBox.Show("không thể sửa theo yêu cầu");

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (is_exists())
            {
                string id_product = cbbID_product.SelectedItem.ToString();
                salesInvoiceDetailBUS.removeInvoiceDetail(invoice_id, id_product);
                DataRow[] rowsToDelete = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("PRODUCT_ID = '" + id_product + "' AND INVOICE_ID = '" + invoice_id + "'");
                SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Remove(rowsToDelete[0]);
                dataGridView1.DataSource = show_data(1);

                decimal sum = show_data(1).AsEnumerable().Sum(row => row.Field<decimal>("PRICE") * row.Field<int>("QUANTITY"));
                txt_payment(sum);
            }
            else
                MessageBox.Show("Đối tượng này chưa được lưu vào danh sách nên không thể xóa");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            cbbID_product.SelectedItem = null;
        }

        private void btnSave_Click(object sender, EventArgs e) // XEM XÉT LẠI CHO ĐỒNG BỘ VỚI NÚT ÁP Ở FORM INVOICEUC
        {
            if (show_data(1).Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có dữ liệu");
                return;
            }

            DataRow rowToUpdate = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == invoice_id);
            SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO(rowToUpdate);
            salesInvoiceDTO.State = "1";
            rowToUpdate[6] = "1";
            salesInvoiceBUS.updateInvoice(salesInvoiceDTO);

            foreach (DataRow row_detail in show_data(1).Rows)
            {
                DataRow row_product = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(_row => _row.Field<string>("ID") == row_detail[1].ToString());
                ProductDTO productDTO = new ProductDTO(row_product);
                productDTO.Quantity -= (int)row_detail[2];
                if (productBUS.updateProduct(productDTO))
                {
                    row_product[6] = productDTO.Quantity;
                    int quantity = (int)row_detail[2];

                    while (true)
                    {
                        var row = StockroomBUS.StockroomList.AsEnumerable().FirstOrDefault(_row => _row.Field<string>("PRODUCT_ID") == row_detail[1].ToString());
                        StockroomDTO stockroomDTO = new StockroomDTO(row);

                        if (stockroomDTO.QUANTITY > quantity)
                        {
                            stockroomDTO.QUANTITY -= quantity;
                            if (stockroomBUS.updateStockroom(stockroomDTO))
                                row[2] = stockroomDTO.QUANTITY;
                            break;
                        }
                        else
                        {
                            if (stockroomBUS.removeStockroom(row[0].ToString()))
                                StockroomBUS.StockroomList.Rows.Remove(row);
                            if (quantity > stockroomDTO.QUANTITY)
                                quantity -= stockroomDTO.QUANTITY;
                            else break;
                        }
                    }
                }
            }
            showdata(1);
            pnlControl.Visible = false;
            pnlPrint.Visible = true;
            Enable_cbbVoucher();
        }

        private DataTable show_data(int index)
        {
            if (index == 1)
            {
                var filteredRows = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().Where(row => row.Field<string>("INVOICE_ID") == invoice_id);
                return filteredRows.Any() ? filteredRows.CopyToDataTable() : SalesInvoiceDetailBUS.SalesInvoiceDetailList.Clone();
            }
            else
            {
                var filteredRows = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows.Any() ? filteredRows.CopyToDataTable() : ProductBUS.ProductList.Clone();
            }
        }

        private bool is_exists()
        {
            if (SalesInvoiceDetailBUS.SalesInvoiceDetailList == null)
            {
                return false;
            }
            DataRow[] check = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("PRODUCT_ID = " + cbbID_product.SelectedItem.ToString() + " AND INVOICE_ID = " + invoice_id);
            if (check.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void lbExit_MouseHover(object sender, EventArgs e)
        {
            lbExit.ForeColor = Color.Red;
            Cursor = Cursors.Hand;
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            lbExit.ForeColor = Color.LightCyan;
            Cursor = Cursors.Default;
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Form mainForm = this.FindForm();
            mainForm.Width -= this.Width;
            Panel panel4 = mainForm.Controls.Find("panel4", true).FirstOrDefault() as Panel;
            panel4.Controls.Remove(this);

            mainForm.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.PrimaryScreen;
            int x = (screen.WorkingArea.Width - mainForm.Width) / 2;
            int y = (screen.WorkingArea.Height - mainForm.Height) / 2;
            mainForm.Location = new Point(x, y);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (cbbID_product.SelectedItem == null)
            {
                return;
            }
            if (pnlControl.Visible)
            {
                DataRow row_product = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == cbbID_product.Text);
                if (numericUpDown1.Value > (int)row_product[6])
                {
                    MessageBox.Show("vượt quá số lượng hàng đang có sẵn");
                    numericUpDown1.Value = (int)row_product[6];
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                numericUpDown1.Value = 0;
                cbbID_product.SelectedItem = null;
                return;
            }

            cbbID_product.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            txtPrice.Text = decimal.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString("#,##0");
        }

        public Panel getP()
        {
            return pnlControl;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataRow _row = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == invoice_id);
            SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO(_row);

            Invoice invoice = new Invoice(salesInvoiceDTO);
            invoice.Show();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PRICE")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void cbbID_invoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID_invoice.SelectedItem == null)
                return;
            else 
                invoice_id = cbbID_invoice.SelectedItem.ToString();
            dataGridView1.DataSource = show_data(1);
        }
    }
}
