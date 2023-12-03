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
    public partial class AddPurchaseInvoiceDetail : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        private StockroomBUS stockroomBUS = new StockroomBUS();
        private PurchaseInvoiceBUS purchaseInvoiceBUS = new PurchaseInvoiceBUS();
        private PurchaseInvoiceDetailBUS purchaseInvoiceDetailBUS = new PurchaseInvoiceDetailBUS();
        private string invoice_id;
        private string provider_id;

        public delegate void truyenDuLieu(decimal txt);
        public truyenDuLieu txt_payment;
        public truyenDuLieu showdata;

        public AddPurchaseInvoiceDetail(string invoice_id, string provider_id)
        {
            InitializeComponent();
            this.invoice_id = invoice_id;
            this.provider_id = provider_id;
            LoadDetail();
        }

        public AddPurchaseInvoiceDetail()
        {
            InitializeComponent();
            LoadDetail();
            pnlControl.Visible = false;
            cbbID_invoice.Enabled = true;
            numericUpDown1.ReadOnly = true;
            cbbID_product.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtPrice.ReadOnly = true;
        }

        private void LoadDetail()
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();
            if(StockroomBUS.StockroomList == null)
                stockroomBUS.getStockroom();
            if (PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList == null)
                purchaseInvoiceDetailBUS.getInvoiceDetail();


            foreach (DataRow row in show_data(2).Rows)
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
            //if (cbbID_product.SelectedItem == null)
            //{
            //    return;
            //}
            //string id_product = cbbID_product.SelectedItem.ToString();

            //DataRow find = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("PRODUCT_ID") == id_product && row.Field<string>("INVOICE_ID") == invoice_id);
            //if (find != null)
            //{
            //    numericUpDown1.Value = find.Field<int>("QUANTITY");
            //    txtPrice.Text = find[3].ToString();
            //}
            //else 
            //{ 
            //    numericUpDown1.Value = 0;
            //    txtPrice.Text = "";
            //}
        }

        private void cbbID_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID_product.SelectedItem == null)
                return;

            string id_product = cbbID_product.SelectedItem.ToString();

            DataRow find = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable().FirstOrDefault(row => row.Field<string>("PRODUCT_ID") == id_product && row.Field<string>("INVOICE_ID") == invoice_id);
            if (find != null)
            {
                numericUpDown1.Value = find.Field<int>("QUANTITY");
                txtPrice.Text = find[3].ToString();
                dateTimePicker1.Value = (DateTime)find[4];
            }
            else
            {
                numericUpDown1.Value = 0;
                txtPrice.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker1.CustomFormat = " ";
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

            PurchaseInvoiceDetailDTO invoiceDetailDTO = new PurchaseInvoiceDetailDTO();
            invoiceDetailDTO.InvoiceId = invoice_id;
            invoiceDetailDTO.ProductId = cbbID_product.SelectedItem.ToString();
            invoiceDetailDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            invoiceDetailDTO.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));
            invoiceDetailDTO.Exp = dateTimePicker1.Value;

            if (purchaseInvoiceDetailBUS.addInvoiceDetail(invoiceDetailDTO))
            {
                PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Rows.Add(invoiceDetailDTO.InvoiceId, invoiceDetailDTO.ProductId, invoiceDetailDTO.Quantity,
                                                                            invoiceDetailDTO.Price, invoiceDetailDTO.Exp);
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
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Không được để trống giá tiền");
                txtPrice.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal number1))
            {
                MessageBox.Show("Sai định dạng, mời nhập lại");
                return false;
            }

            if (dateTimePicker1.CustomFormat == " ")
            {
                MessageBox.Show("Không được để hạn sử dụng");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!is_exists())
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể sửa");
                return;
            }
            if (!check())
                return;

            PurchaseInvoiceDetailDTO invoiceDetailDTO = new PurchaseInvoiceDetailDTO();
            invoiceDetailDTO.InvoiceId = invoice_id;
            invoiceDetailDTO.ProductId = cbbID_product.SelectedItem.ToString();
            invoiceDetailDTO.Quantity = int.Parse(numericUpDown1.Value.ToString());
            invoiceDetailDTO.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));
            invoiceDetailDTO.Exp = dateTimePicker1.Value;

            if (purchaseInvoiceDetailBUS.updateInvoiceDetail(invoiceDetailDTO))
            {
                DataRow rowToUpdate = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable().FirstOrDefault
                    (row => row.Field<string>("INVOICE_ID") == invoiceDetailDTO.InvoiceId && row.Field<string>("PRODUCT_ID") == invoiceDetailDTO.ProductId);

                if (rowToUpdate != null)
                {
                    rowToUpdate[2] = invoiceDetailDTO.Quantity;
                    rowToUpdate[3] = invoiceDetailDTO.Price;
                    rowToUpdate[4] = invoiceDetailDTO.Exp;
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
                purchaseInvoiceDetailBUS.removeInvoiceDetail(invoice_id, id_product);
                DataRow[] rowsToDelete = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("PRODUCT_ID = '" + id_product + "' AND INVOICE_ID = '" + invoice_id + "'");
                PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Rows.Remove(rowsToDelete[0]);
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
            txtPrice.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = " ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (show_data(1).Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có dữ liệu");
                return;
            }

            DataRow rowToUpdate = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == invoice_id);
            PurchaseInvoiceDTO purchaseInvoiceDTO = new PurchaseInvoiceDTO(rowToUpdate);

            purchaseInvoiceDTO.State = "1"; // vế sau từ từ tính nè
            if (purchaseInvoiceBUS.updateInvoice(purchaseInvoiceDTO))
            {
                rowToUpdate[5] = "1";

                var filteredRows = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable().Where(row => row.Field<string>("INVOICE_ID") == invoice_id);
                int id_stockroom;
                if (StockroomBUS.StockroomList.Rows.Count > 0)
                    id_stockroom = int.Parse(StockroomBUS.StockroomList.Rows[StockroomBUS.StockroomList.Rows.Count - 1]["ID"].ToString()) + 1;
                else
                    id_stockroom = 100000;

                foreach (var row in filteredRows)
                {
                    StockroomDTO stockroomDTO = new StockroomDTO();
                    stockroomDTO.ID = id_stockroom.ToString();
                    stockroomDTO.PRODUCT_ID = row[1].ToString();
                    stockroomDTO.QUANTITY = (int)row[2];
                    stockroomDTO.EXP = (DateTime)row[4];
                    if (stockroomBUS.addStockroom(stockroomDTO))
                    {
                        StockroomBUS.StockroomList.Rows.Add(stockroomDTO.ID, stockroomDTO.PRODUCT_ID, stockroomDTO.QUANTITY, stockroomDTO.EXP);
                        //MessageBox.Show("Cập nhật vào kho hàng");

                        DataRow find = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(_row => _row.Field<string>("ID") == stockroomDTO.PRODUCT_ID);
                        ProductDTO productDTO = new ProductDTO(find);
                        productDTO.Price = updatePrice((decimal)row[3]);
                        productDTO.Quantity += stockroomDTO.QUANTITY;
                        if (productBUS.updateProduct(productDTO)){
                            find[5] = productDTO.Price;
                            find[6] = productDTO.Quantity;
                        }
                        showdata(2);
                    }
                    else
                        MessageBox.Show("Không đưa vào kho hàng được");
                    id_stockroom += 1;
                }
            }
            pnlControl.Visible = false;
        }

        private DataTable show_data(int index)
        {
            if(index == 1)
            {
                var filteredRows = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable().Where(row => row.Field<string>("INVOICE_ID") == invoice_id);
                return filteredRows.Any() ? filteredRows.CopyToDataTable() : PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Clone();
            }
            else
            {
                var filteredRows = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("PROVIDER_ID") == provider_id);
                return filteredRows.Any() ? filteredRows.CopyToDataTable() : ProductBUS.ProductList.Clone();
            }
        }

        private bool is_exists()
        {
            if (show_data(1).Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có dữ liệu");
                return false;
            }
            if (PurchaseInvoiceBUS.PurchaseInvoiceList == null)
            {
                return false;
            }
            DataRow[] check = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("PRODUCT_ID = " + cbbID_product.SelectedItem.ToString() + " AND INVOICE_ID = " + invoice_id);
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                numericUpDown1.Value = 0;
                cbbID_product.SelectedItem = null;
                return;
            }
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            cbbID_product.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            txtPrice.Text = decimal.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString("#,##0");
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.CustomFormat == " ")
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "EXP")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "PRICE")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }
        }

        public Panel getP()
        {
            return pnlControl;
        }

        private decimal updatePrice(decimal PurchasePrice)
        {
            return PurchasePrice * 1.6m;
        }

        private void btnPD_Click(object sender, EventArgs e)
        {

        }
    }
}
