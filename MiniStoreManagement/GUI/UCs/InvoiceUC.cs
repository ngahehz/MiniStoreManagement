using MiniStoreManagement.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MiniStoreManagement.GUI.items;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class InvoiceUC : UserControl
    {
        private SalesInvoiceBUS salesInvoiceBUS = new SalesInvoiceBUS();
        private PurchaseInvoiceBUS purchaseInvoiceBUS = new PurchaseInvoiceBUS();
        private bool id_focus = false;
        public InvoiceUC()
        {
            InitializeComponent();
        }

        private void InvoiceUC_Load(object sender, EventArgs e)
        {
            if (SalesInvoiceBUS.SalesInvoiceList == null)
                salesInvoiceBUS.getInvoice();
            if (PurchaseInvoiceBUS.PurchaseInvoiceList == null)
                purchaseInvoiceBUS.getInvoice();
            new_id1();
            new_id2();

            dataGridView1.DataSource = SalesInvoiceBUS.SalesInvoiceList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "EMPLOYEE_ID";
            dataGridView1.Columns[2].HeaderText = "DATE";
            dataGridView1.Columns[3].HeaderText = "TOTAL_PAYMENT";
            dataGridView1.Columns[4].HeaderText = "CONSUMER_ID";
            dataGridView1.Columns[5].HeaderText = "VOUCHER_ID";

            dataGridView2.DataSource = PurchaseInvoiceBUS.PurchaseInvoiceList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "EMPLOYEE_ID";
            dataGridView1.Columns[2].HeaderText = "DATE";
            dataGridView1.Columns[3].HeaderText = "TOTAL_PAYMENT";
            dataGridView1.Columns[4].HeaderText = "PROVIDER_ID";
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "DATE")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true; // Đánh dấu rằng định dạng đã được áp dụng
                }
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form1();
                return;
            }
            id_focus = true;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            txtID1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPayment1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbbID_employee1.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbID_consumer1.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbbID_voucher1.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form2();
                return;
            }
            id_focus = true;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            txtID2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtPayment2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            cbbID_employee2.SelectedItem = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cbbID_provider2.SelectedItem = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
        }

        private void new_id1()
        {
            if (SalesInvoiceBUS.SalesInvoiceList.Rows.Count > 0)
            {
                txtID1.Text = ((int)SalesInvoiceBUS.SalesInvoiceList.Rows[SalesInvoiceBUS.SalesInvoiceList.Rows.Count - 1]["ID"] + 1).ToString();
                return;
            }
            txtID1.Text = "100000";
        }

        private void new_id2()
        {
            if (PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Count > 0)
            {
                txtID1.Text = ((int)PurchaseInvoiceBUS.PurchaseInvoiceList.Rows[PurchaseInvoiceBUS.PurchaseInvoiceList.Rows.Count - 1]["ID"] + 1).ToString();
                return;
            }
            txtID1.Text = "100000";
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }
        private void reset_form1()
        {
            id_focus = false;
            new_id1();
            cbbID_consumer1.SelectedIndex = 0;
            cbbID_employee1.SelectedIndex = 0;
            cbbID_voucher1.SelectedIndex = 0;
            dateTimePicker1.CustomFormat = " ";
            txtPayment1.ResetText();
            txtSearch1.ResetText();
        }

        private void reset_form2()
        {
            id_focus = false;
            new_id2();
            cbbID_employee2.SelectedIndex = 0;
            cbbID_provider2.SelectedIndex = 0;
            dateTimePicker2.CustomFormat = " ";
            txtPayment2.ResetText();
            txtSearch2.ResetText();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
        }
    }
}
