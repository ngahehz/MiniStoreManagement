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
using MiniStoreManagement.GUI.items;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class InvoiceUC : UserControl
    {
        private SalesInvoiceBUS salesInvoiceBUS = new SalesInvoiceBUS();
        private PurchaseInvoiceBUS purchaseInvoiceBUS = new PurchaseInvoiceBUS();
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();
        private PurchaseInvoiceDetailBUS purchaseInvoiceDetailBUS = new PurchaseInvoiceDetailBUS();
        private VoucherBUS voucherBUS = new VoucherBUS();
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private ConsumerBUS consumerBUS = new ConsumerBUS();
        private ProviderBUS providerBUS = new ProviderBUS();

        private int id = 0; // id tạm để t check control print thôi
        private bool id_voucher = false;
        private bool id_focus1 = false;
        private bool id_focus2 = false;
        private string _state = "1";
        public InvoiceUC()
        {
            InitializeComponent();
        }

        public InvoiceUC(string i)
        {
            InitializeComponent();

            _state = i;
            btnUpdate1.Visible = false;
            btnUpdate2.Visible = false;
            btnAdd1.Visible = false;
            btnAdd2.Visible = false;
            btnDel1.Visible = false;
            btnDel2.Visible = false;
            btnNew1.Text = "Xóa";
            btnNew2.Text = "Xóa";
            //btnDel1.Text = "Hoàn";
            //btnDel2.Text = "Hoàn";
            cbbID_consumer1.Enabled = false;
            cbbID_employee1.Enabled = false;
            cbbID_employee2.Enabled = false;
            cbbID_provider2.Enabled = false;
            dateTimePicker2.Enabled = false;
            make_center();
        }

        public void make_center()
        {
            int panelHeight = panel2.Height;
            int buttonHeight1 = btnAdd1.Height;
            int buttonHeight2 = btnAdd2.Height;

            int yPositionButton1 = (panelHeight - buttonHeight1) / 2;
            int yPositionButton2 = (panelHeight - buttonHeight2) / 2;

            btnNew1.Location = new Point(btnNew1.Location.X, yPositionButton1);
            btnNew2.Location = new Point(btnNew1.Location.X, yPositionButton2);
        }

        private void InvoiceUC_Load(object sender, EventArgs e)
        {
            if (EmployeeBUS.EmployeeList == null)
                employeeBUS.getEmployee();

            foreach (DataRow row in show_data(3).Rows)
            {
                cbbID_employee1.Items.Add(row["ID"].ToString());
                cbbID_employee2.Items.Add(row["ID"].ToString());
            }

            loadTab1();
            loadTab2();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "DATE")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }

            if (dgv.Columns[e.ColumnIndex].Name == "TOTAL_PAYMENT")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }
        }

        private DataTable show_data(int temp)
        {
            if (temp == 1)
            {
                var filteredRows1 = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().Where(row => row.Field<string>("STATE") == _state);
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : SalesInvoiceBUS.SalesInvoiceList.Clone();
            }
            else if (temp == 2)
            {
                var filteredRows1 = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().Where(row => row.Field<string>("STATE") == _state);
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : PurchaseInvoiceBUS.PurchaseInvoiceList.Clone();
            }
            else if (temp == 3)
            {
                var filteredRows1 = EmployeeBUS.EmployeeList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : EmployeeBUS.EmployeeList.Clone();
            }
            else // tmep 4
            {
                var filteredRows1 = ProviderBUS.ProviderList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : ProviderBUS.ProviderList.Clone();
            }
        }

        public void showdata(decimal i)
        {
            if (i == 1)
                dataGridView1.DataSource = show_data(1);
            else
                dataGridView2.DataSource = show_data(2);
        }


        // TAB 1 CHO SALES INVOICE
        private void loadTab1()
        {
            if (SalesInvoiceBUS.SalesInvoiceList == null)
                salesInvoiceBUS.getInvoice();
            if (VoucherBUS.VoucherList == null)
                voucherBUS.getVoucher();
            if (ConsumerBUS.ConsumerList == null)
                consumerBUS.getConsumer();

            new_id1();
            dataGridView1.DataSource = show_data(1);
            dataGridView1.Columns["STATE"].Visible = false;

            foreach (DataRow row in VoucherBUS.VoucherList.Rows)
            {
                cbbID_voucher1.Items.Add(row["ID"].ToString());
            }
            foreach (DataRow row in ConsumerBUS.ConsumerList.Rows)
            {
                cbbID_consumer1.Items.Add(row["ID"].ToString());
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            reset_form1();
            if (show_data(1).Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
                return;
            id_focus1 = true;
            //dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            txtID1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPayment1.Text = decimal.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()).ToString("#,##0");
            cbbID_employee1.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbID_consumer1.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbbID_voucher1.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            id = int.Parse(txtID1.Text);
            btnPrint.Visible = true;
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            if (_state == "0")
            {
                if (!id_focus1)
                {
                    MessageBox.Show("Chưa chọn đối tượng, không thể xóa");
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DataRow[] rowsToDelete = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("INVOICE_ID = '" + txtID1.Text + "'");
                    foreach (DataRow row in rowsToDelete)
                    {
                        if(salesInvoiceDetailBUS.removeInvoiceDetail(row[0].ToString(), row[1].ToString()))
                            SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Remove(row);
                    }

                    if (salesInvoiceBUS.removeInvoice(txtID1.Text))
                    {
                        rowsToDelete = SalesInvoiceBUS.SalesInvoiceList.Select("ID = '" + txtID1.Text + "'");
                        SalesInvoiceBUS.SalesInvoiceList.Rows.Remove(rowsToDelete[0]);
                        showdata(1);
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                        MessageBox.Show("Không thể xóa đối tượng!");
                }
            }
            else
            {
                dataGridView1.ClearSelection();
                reset_form1();
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (!checkUC1())
                return;

            if (id_focus1)
            {
                MessageBox.Show("Ấn nút mới để tạo mới form");
                return;
            }
            if (!check1())
                return;

            SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO();
            salesInvoiceDTO.Id = txtID1.Text;
            salesInvoiceDTO.EmployeeId = cbbID_employee1.SelectedItem.ToString();

            if (cbbID_consumer1.SelectedItem != null)
                salesInvoiceDTO.ConsumerId = cbbID_consumer1.SelectedItem.ToString();
            else
                salesInvoiceDTO.ConsumerId = null;

            if (cbbID_voucher1.SelectedItem != null)
                salesInvoiceDTO.VoucherId = cbbID_voucher1.SelectedItem.ToString();
            else
                salesInvoiceDTO.VoucherId = null;

            salesInvoiceDTO.Date = dateTimePicker1.Value;
            salesInvoiceDTO.TotalPayment = decimal.Parse(txtPayment1.Text);

            if (salesInvoiceBUS.addInvoice(salesInvoiceDTO))
            {
                SalesInvoiceBUS.SalesInvoiceList.Rows.Add(salesInvoiceDTO.Id, salesInvoiceDTO.EmployeeId, salesInvoiceDTO.Date, salesInvoiceDTO.TotalPayment,
                                                          salesInvoiceDTO.ConsumerId, salesInvoiceDTO.VoucherId, salesInvoiceDTO.State);
                dataGridView1.DataSource = show_data(1);
                id_focus1 = true;
                MessageBox.Show("Mời bạn nhập thông tin hóa đơn");
            }
            else
            {
                MessageBox.Show("Lỗi không thể thêm thành công");
                return;
            }

            AddSalesInvoiceDetail addSalesInvoiceDetail = new AddSalesInvoiceDetail(txtID1.Text);
            addSalesInvoiceDetail.txt_payment = new AddSalesInvoiceDetail.truyenDuLieu(Payment1);
            addSalesInvoiceDetail.showdata = new AddSalesInvoiceDetail.truyenDuLieu(showdata);
            addSalesInvoiceDetail.Enable_cbbVoucher = new AddSalesInvoiceDetail.truyenDuLieu2(Enable_cbbVoucher);
            addSalesInvoiceDetail.Dock = DockStyle.Right;
            this.Dock = DockStyle.Left;

            addUC1(addSalesInvoiceDetail);
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (!id_focus1)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể sửa");
                return;
            }
            DataRow rowToUpdate = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID1.Text);
            if (rowToUpdate[6].ToString() != "0")
            {
                if (!check1())
                    return;

                MessageBox.Show("Đối tượng này đã được hoàn thành nên không thể sửa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO(rowToUpdate);
                salesInvoiceDTO.EmployeeId = cbbID_employee1.SelectedItem.ToString();

                if (cbbID_consumer1.SelectedItem != null)
                    salesInvoiceDTO.ConsumerId = cbbID_consumer1.SelectedItem.ToString();
                else
                    salesInvoiceDTO.ConsumerId = null;

                if (salesInvoiceBUS.updateInvoice(salesInvoiceDTO))
                {
                    rowToUpdate[1] = salesInvoiceDTO.EmployeeId;
                    rowToUpdate[4] = salesInvoiceDTO.ConsumerId;
                    MessageBox.Show("Đã sửa");
                }
                else
                    MessageBox.Show("không thể làm theo yêu cầu");
            }
        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            if (!id_focus1)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể xóa");
                return;
            }
            DataRow rowToDelete = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID1.Text);
            if (rowToDelete[6].ToString() != "0")
            {
                MessageBox.Show("Đối tượng này đã được hoàn thành nên không thể xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataRow[] rowsToDelete = SalesInvoiceDetailBUS.SalesInvoiceDetailList.Select("INVOICE_ID = " + txtID1.Text);
                foreach (DataRow row in rowsToDelete)
                {
                    if (salesInvoiceDetailBUS.removeInvoiceDetail(txtID1.Text, row[1].ToString()))
                        SalesInvoiceDetailBUS.SalesInvoiceDetailList.Rows.Remove(row);
                    else
                    {
                        MessageBox.Show("Không xóa được ct hóa đơn");
                        return;
                    }
                }

                if (salesInvoiceBUS.removeInvoice(txtID1.Text))
                {
                    SalesInvoiceBUS.SalesInvoiceList.Rows.Remove(rowToDelete);
                    MessageBox.Show("Đã xóa thành công");
                }
                else
                {
                    MessageBox.Show("Lỗi, không thể xóa thành công");
                }
            }
        }

        private void btnCTHD1_Click(object sender, EventArgs e)
        {
            if (!checkUC1())
                return;

            AddSalesInvoiceDetail addSalesInvoiceDetail = new AddSalesInvoiceDetail();
            addSalesInvoiceDetail.Dock = DockStyle.Right;
            this.Dock = DockStyle.Left;
            addUC1(addSalesInvoiceDetail);
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = show_data(1).DefaultView;
            string txt = txtSearch1.Text;

            if (txtSearch1.Text == "")
            {
                dv.RowFilter = "ID LIKE '%1%'";
                dataGridView1.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR EMPLOYEE_ID LIKE '%{txt}%' OR CONSUMER_ID LIKE '%{txt}%' OR VOUCHER_ID LIKE '%{txt}%' "
                         + $"OR CONVERT(TOTAL_PAYMENT, 'System.String') LIKE '%{txt}%'";
            dataGridView1.DataSource = dv.ToTable();
        }

        private void new_id1()
        {
            if (SalesInvoiceBUS.SalesInvoiceList.Rows.Count > 0)
            {
                txtID1.Text = (int.Parse(SalesInvoiceBUS.SalesInvoiceList.Rows[SalesInvoiceBUS.SalesInvoiceList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID1.Text = "100000";
        }

        private void reset_form1()
        {
            id_focus1 = false;
            btnPrint.Visible = false;
            new_id1();
            cbbID_consumer1.SelectedItem = null;
            cbbID_employee1.SelectedItem = null;
            cbbID_voucher1.SelectedItem = null;
            dateTimePicker1.Value = DateTime.Now;
            txtPayment1.Text = "0";
            txtSearch1.ResetText();
        }

        private bool check1()
        {
            if (cbbID_employee1.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống id nhân viên");
                cbbID_employee1.Focus();
                return false;
            }
            //if (cbbID_consumer1.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Không được để trống id khách hàng");
            //    cbbID_consumer1.Focus();
            //    return false;
            //}

            return true;
        }

        private void Enable_cbbVoucher()
        {
            cbbID_voucher1.Enabled = false;
            btn.Visible = false;
        }

        private void Payment1(decimal price)
        {
            txtPayment1.Text = price.ToString("#,##0");
            cbbID_voucher1.SelectedItem = null;
            id_voucher = false;
            updateSalesInvoice();
        }

        private void txtPayment1_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPayment1.Text))
            {
                cbbID_voucher1.SelectedItem = null;
                cbbID_voucher1.Enabled = false;
                return; 
            }
            cbbID_voucher1.Enabled = true;
        }

        private void cbbID_voucher1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID_voucher1.SelectedItem == null)
            {
                btn.Visible = false;
                return;
            }
            btn.Visible = true;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (id_voucher)
                return;
            string vou_id = cbbID_voucher1.Text;
            decimal payment = decimal.Parse(txtPayment1.Text.Replace(",", ""));

            DataRow _row = VoucherBUS.VoucherList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == vou_id);
            if (_row != null)
            {
                if (!string.IsNullOrWhiteSpace(_row[3].ToString()))
                {
                    decimal discount = (decimal)_row[3];
                    decimal min_invoice = (decimal)_row[4];
                    if (payment < min_invoice)
                    {
                        MessageBox.Show("Giá trị phải từ " + min_invoice.ToString("#,##0") + "trở lên");
                        cbbID_voucher1.SelectedItem = null;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Bạn được giảm " + discount.ToString("#,##0"));
                        txtPayment1.Text = (payment - discount).ToString("#,##0");
                        updateSalesInvoice();
                    }
                }
                else
                {
                    decimal percent = decimal.Parse(_row[5].ToString());
                    decimal max_discount = (decimal)_row[6];
                    if (payment * percent > max_discount)
                    {
                        MessageBox.Show("Bạn được giảm " + max_discount.ToString("#,##0"));
                        txtPayment1.Text = (payment - max_discount).ToString("#,##0");
                        updateSalesInvoice();
                    }
                    else
                    {
                        MessageBox.Show("Bạn được giảm " + (payment * percent).ToString("#,##0"));
                        txtPayment1.Text = (payment * (1 - percent)).ToString("#,##0");
                        updateSalesInvoice();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbID_consumer1.SelectedIndex = -1;
        }

        private void updateSalesInvoice() // cần sửa thêm cho nút button sửa
        {
            // hàm này kiểu mỗi lần thay đổi giá tiền hay voucher là nó thay đổi trong data luôn
            DataRow _row = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID1.Text);
            SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO(_row);

            salesInvoiceDTO.TotalPayment = decimal.Parse(txtPayment1.Text.Replace(",", ""));

            if (cbbID_voucher1.SelectedItem != null)
                salesInvoiceDTO.VoucherId = cbbID_voucher1.SelectedItem.ToString();
            else
                salesInvoiceDTO.VoucherId = null;

            _row[3] = salesInvoiceDTO.TotalPayment;
            _row[5] = salesInvoiceDTO.VoucherId;
            salesInvoiceBUS.updateInvoice(salesInvoiceDTO);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                return;
            }

            DataRow _row = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID1.Text);
            SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO(_row);

            Invoice invoice = new Invoice(salesInvoiceDTO);
            invoice.Show();
        }

        private bool checkUC1()
        {
            Form main = this.FindForm();
            Panel pn = main.Controls.Find("panel4", true).FirstOrDefault() as Panel;

            foreach (Control control in pn.Controls)
            {
                if (control is AddSalesInvoiceDetail)
                {
                    AddSalesInvoiceDetail ASID = (AddSalesInvoiceDetail)control;
                    if (ASID.getP().Visible)
                    {
                        MessageBox.Show("Hãy hoàn thành công việc");
                        return false;
                    }
                    else
                    {
                        main.Width -= ASID.Width;
                        main.Controls.Remove(ASID);

                        main.StartPosition = FormStartPosition.Manual;
                        Screen sc = Screen.PrimaryScreen;
                        int z = (sc.WorkingArea.Width - main.Width) / 2;
                        int w = (sc.WorkingArea.Height - main.Height) / 2;
                        main.Location = new Point(z, w);
                    }
                }
            }
            return true;
        }

        private void addUC1(AddSalesInvoiceDetail addSalesInvoiceDetail)
        {
            Form main = this.FindForm();
            main.Width += addSalesInvoiceDetail.Width;
            Panel pn = main.Controls.Find("panel4", true).FirstOrDefault() as Panel;
            pn.Controls.Add(addSalesInvoiceDetail);

            main.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.PrimaryScreen;
            int x = (screen.WorkingArea.Width - main.Width) / 2;
            int y = (screen.WorkingArea.Height - main.Height) / 2;
            main.Location = new Point(x, y);
        }

        // TAB 2 CHO PURCHASE INVOICE
        private void loadTab2()
        {
            if (PurchaseInvoiceBUS.PurchaseInvoiceList == null)
                purchaseInvoiceBUS.getInvoice();
            if (ProviderBUS.ProviderList == null)
                providerBUS.getProvider();

            new_id2();
            dataGridView2.DataSource = show_data(2);
            dataGridView2.Columns["STATE"].Visible = false;

            foreach (DataRow row in show_data(4).Rows)
            {
                cbbID_provider2.Items.Add(row["ID"].ToString());
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            reset_form2();
            if (show_data(2).Rows.Count == 0)
                return;

            if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == "")
                return;
            id_focus2 = true;
            //dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            txtID2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtPayment2.Text = decimal.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString()).ToString("#,##0");
            cbbID_employee2.SelectedItem = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cbbID_provider2.SelectedItem = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            dateTimePicker2.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
        }

        private void btnNew2_Click(object sender, EventArgs e)
        {
            if (_state == "0")
            {
                if (!id_focus2)
                {
                    MessageBox.Show("Chưa chọn đối tượng, không thể xóa");
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DataRow[] rowsToDelete = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("INVOICE_ID = '" + txtID2.Text + "'");
                    foreach (DataRow row in rowsToDelete)
                    {
                        if (purchaseInvoiceDetailBUS.removeInvoiceDetail(row[0].ToString(), row[1].ToString()))
                            PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Rows.Remove(row);
                    }

                    if (purchaseInvoiceBUS.removeInvoice(txtID2.Text))
                    {
                        rowsToDelete = PurchaseInvoiceBUS.PurchaseInvoiceList.Select("ID = '" + txtID2.Text + "'");
                        PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Remove(rowsToDelete[0]);
                        showdata(2);
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                        MessageBox.Show("Không thể xóa đối tượng!");
                }
            }
            else
            {
                dataGridView2.ClearSelection();
                reset_form2();
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (!checkUC2())
                return;

            if (id_focus2)
            {
                MessageBox.Show("Ấn nút mới để tạo mới form");
                return;
            }
            if (!check2())
                return;

            PurchaseInvoiceDTO purchaseInvoiceDTO = new PurchaseInvoiceDTO();
            purchaseInvoiceDTO.Id = txtID2.Text;
            purchaseInvoiceDTO.ProviderId = cbbID_provider2.SelectedItem.ToString();
            purchaseInvoiceDTO.EmployeeId = cbbID_employee2.SelectedItem.ToString();
            purchaseInvoiceDTO.Date = dateTimePicker2.Value;
            purchaseInvoiceDTO.TotalPayment = decimal.Parse(txtPayment2.Text);

            if (purchaseInvoiceBUS.addInvoice(purchaseInvoiceDTO))
            {
                PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Add(purchaseInvoiceDTO.Id, purchaseInvoiceDTO.EmployeeId, purchaseInvoiceDTO.Date, purchaseInvoiceDTO.TotalPayment,
                                                                purchaseInvoiceDTO.ProviderId, purchaseInvoiceDTO.State);
                dataGridView2.DataSource = show_data(2);
                dataGridView2.Columns["STATE"].Visible = false;
                id_focus2 = true;
                MessageBox.Show("Mời bạn nhập thông tin hóa đơn");
            }
            else
            {
                MessageBox.Show("Lỗi không thể thêm thành công");
                return;
            }

            AddPurchaseInvoiceDetail addPurchaseDetailInvoice = new AddPurchaseInvoiceDetail(txtID2.Text, cbbID_provider2.Text);
            addPurchaseDetailInvoice.txt_payment = new AddPurchaseInvoiceDetail.truyenDuLieu(Payment2);
            addPurchaseDetailInvoice.showdata = new AddPurchaseInvoiceDetail.truyenDuLieu(showdata); 
            addPurchaseDetailInvoice.Dock = DockStyle.Right;
            this.Dock = DockStyle.Left;

            addUC2(addPurchaseDetailInvoice);
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            if (!id_focus2)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể sửa");
                return;
            }
            DataRow rowToUpdate = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID2.Text);
            if (rowToUpdate[5].ToString() != "0")
            {
                if (cbbID_employee2.SelectedIndex == -1)
                {
                    MessageBox.Show("Không được để trống id nhân viên");
                    cbbID_employee2.Focus();
                    return;
                }

                MessageBox.Show("Đối tượng này đã được hoàn thành nên không thể sửa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                PurchaseInvoiceDTO purchaseInvoiceDTO = new PurchaseInvoiceDTO(rowToUpdate);
                purchaseInvoiceDTO.EmployeeId = cbbID_employee2.SelectedItem.ToString();

                if (cbbID_provider2.SelectedItem == null || cbbID_provider2.SelectedItem.ToString() != purchaseInvoiceDTO.ProviderId)
                {
                    MessageBox.Show("Không thể chỉnh sửa nguồn cung, hãy xóa hóa đơn này hoặc tạo mới hóa đơn !");
                    cbbID_provider2.SelectedItem = purchaseInvoiceDTO.ProviderId;
                }

                if (purchaseInvoiceBUS.updateInvoice(purchaseInvoiceDTO))
                {
                    rowToUpdate[1] = purchaseInvoiceDTO.EmployeeId;
                    MessageBox.Show("Đã sửa");
                }
                else
                    MessageBox.Show("không thể làm theo yêu cầu");
            }
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            if (!id_focus2)
            {
                MessageBox.Show("Đối tượng chưa được lưu nên không thể xóa");
                return;
            }
            DataRow rowToDelete = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID2.Text);
            if (rowToDelete[5].ToString() != "0")
            {
                MessageBox.Show("Đối tượng này đã được hoàn thành nên không thể xóa");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Thông báo: Bạn có muốn thực hiện hành động này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataRow[] rowsToDelete = PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Select("INVOICE_ID = " + txtID2.Text);
                foreach (DataRow row in rowsToDelete)
                {
                    if (purchaseInvoiceDetailBUS.removeInvoiceDetail(txtID2.Text, row[1].ToString()))
                        PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.Rows.Remove(row);
                    else
                    {
                        MessageBox.Show("Không xóa được ct hóa đơn");
                        return;
                    }
                }

                if (purchaseInvoiceBUS.removeInvoice(txtID2.Text))
                {
                    PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Remove(rowToDelete);
                    MessageBox.Show("Đã xóa thành công");
                }
                else
                {
                    MessageBox.Show("Lỗi, không thể xóa thành công");
                }
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            DataView dv = show_data(2).DefaultView;
            string txt = txtSearch2.Text;

            if (txtSearch2.Text == "")
            {
                dv.RowFilter = "ID LIKE '%1%'";
                dataGridView2.DataSource = dv.ToTable();
                return;
            }

            dv.RowFilter = $"ID LIKE '%{txt}%' OR EMPLOYEE_ID LIKE '%{txt}%' OR PROVIDER_ID LIKE '%{txt}%' "
                         + $"OR CONVERT(TOTAL_PAYMENT, 'System.String') LIKE '%{txt}%'";
            dataGridView2.DataSource = dv.ToTable();
        }

        private void new_id2()
        {
            if (PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Count > 0)
            {
                txtID2.Text = (int.Parse(PurchaseInvoiceBUS.PurchaseInvoiceList.Rows[PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Count - 1]["ID"].ToString()) + 1).ToString();
                return;
            }
            txtID2.Text = "100000";
        }

        private void reset_form2()
        {
            id_focus2 = false;
            new_id2();
            cbbID_employee2.SelectedItem = null;
            cbbID_provider2.SelectedItem = null;
            dateTimePicker2.Value = DateTime.Now;
            txtPayment2.Text = "0";
            txtSearch2.ResetText();
        }

        private bool check2()
        {
            if (cbbID_employee2.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống id nhân viên");
                cbbID_employee2.Focus();
                return false;
            }
            if (cbbID_provider2.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống id nguồn cung");
                cbbID_provider2.Focus();
                return false;
            }

            return true;
        }

        private void Payment2(decimal price)
        {
            txtPayment2.Text = price.ToString("#,##0");
            updatePurchaseInvoice();
        }

        private void updatePurchaseInvoice()
        {
            DataRow _row = PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID2.Text);
            PurchaseInvoiceDTO purchaseInvoiceDTO = new PurchaseInvoiceDTO(_row);

            purchaseInvoiceDTO.TotalPayment = decimal.Parse(txtPayment2.Text.Replace(",", ""));

            _row[3] = purchaseInvoiceDTO.TotalPayment;
            purchaseInvoiceBUS.updateInvoice(purchaseInvoiceDTO);
        }

        private bool checkUC2()
        {
            Form main = this.FindForm();
            Panel pn = main.Controls.Find("panel4", true).FirstOrDefault() as Panel;

            foreach (Control control in pn.Controls)
            {
                if (control is AddPurchaseInvoiceDetail)
                {
                    AddPurchaseInvoiceDetail APID = (AddPurchaseInvoiceDetail)control;
                    if (APID.getP().Visible)
                    {
                        MessageBox.Show("Hãy hoàn thành công việc");
                        return false;
                    }
                    else
                    {
                        main.Width -= APID.Width;
                        main.Controls.Remove(APID);

                        main.StartPosition = FormStartPosition.Manual;
                        Screen sc = Screen.PrimaryScreen;
                        int z = (sc.WorkingArea.Width - main.Width) / 2;
                        int w = (sc.WorkingArea.Height - main.Height) / 2;
                        main.Location = new Point(z, w);
                    }
                }
            }
            return true;
        }

        private void addUC2(AddPurchaseInvoiceDetail addPurchaseDetailInvoice)
        {
            Form main = this.FindForm();
            Panel pn = main.Controls.Find("panel4", true).FirstOrDefault() as Panel;
            main.Width += addPurchaseDetailInvoice.Width;
            pn.Controls.Add(addPurchaseDetailInvoice);

            main.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.PrimaryScreen;
            int x = (screen.WorkingArea.Width - main.Width) / 2;
            int y = (screen.WorkingArea.Height - main.Height) / 2;
            main.Location = new Point(x, y);
        }

        private void btnCTHD2_Click(object sender, EventArgs e)
        {
            if (!checkUC2())
                return;

            AddPurchaseInvoiceDetail addPurchaseDetailInvoice = new AddPurchaseInvoiceDetail();
            addPurchaseDetailInvoice.Dock = DockStyle.Right;
            this.Dock = DockStyle.Left;
            addUC2(addPurchaseDetailInvoice);
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {

        }

        
    }
}


//private DataTable show_data_vou()
//{
//    var filteredRows = VoucherBUS.VoucherList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
//    return filteredRows.Any() ? filteredRows.CopyToDataTable() : null;
//}

//private DataTable show_data_detail()
//{
//    var filteredRows1 = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().Where(row => row.Field<string>("INVOICE_ID") == txtID1.Text);
//    return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : EmployeeBUS.EmployeeList.Clone();
//}

//private void BtnPrint_Click(object sender, EventArgs e)
//{
//    if (id == 0)
//    {
//        return;
//    }

//    DataRow _row = SalesInvoiceBUS.SalesInvoiceList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID1.Text);
//    SalesInvoiceDTO salesInvoiceDTO = new SalesInvoiceDTO(_row);

//    Invoice invoice = new Invoice(salesInvoiceDTO);
//    invoice.Show();
//}
