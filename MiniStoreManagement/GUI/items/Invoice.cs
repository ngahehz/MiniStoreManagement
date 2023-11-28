using MiniStoreManagement.BUS;
using MiniStoreManagement.DAO;
using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.UCs;
using MySqlX.XDevAPI.Relational;
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
    public partial class Invoice : Form
    {
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        public Invoice(SalesInvoiceDTO salesInvoiceDTO)
        {
            InitializeComponent();
            Details(salesInvoiceDTO);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Details(SalesInvoiceDTO salesInvoiceDTO)
        {
            if( SalesInvoiceDetailBUS.SalesInvoiceDetailList == null )
            {
                salesInvoiceDetailBUS.getInvoiceDetail();
            }
            if (EmployeeBUS.EmployeeList == null)
            {
                employeeBUS.getEmployee();
            }

            lbInvoice.Text = "Số HĐ : " + salesInvoiceDTO.Id;
            lbDate.Text = lbDate.Text + salesInvoiceDTO.Date.ToString("dd/MM/yyyy");
            lbPayment.Text = salesInvoiceDTO.TotalPayment.ToString("#,##0");

            DataRow row = EmployeeBUS.EmployeeList.AsEnumerable().FirstOrDefault(r => r.Field<string>("ID") == salesInvoiceDTO.EmployeeId);
            lbEmployee.Text = lbEmployee.Text + row["NAME"];
            
            var find = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().Where(lane => lane.Field<string>("INVOICE_ID") == salesInvoiceDTO.Id);

            foreach (var _row in find)
            {
                SalesInvoiceDetailDTO invoiceDetailDTO = new SalesInvoiceDetailDTO();
                invoiceDetailDTO.InvoiceId = _row.Field<string>("INVOICE_ID");
                invoiceDetailDTO.ProductId = _row.Field<string>("PRODUCT_ID");
                invoiceDetailDTO.Quantity = _row.Field<int>("QUANTITY");
                invoiceDetailDTO.Price = _row.Field<decimal>("PRICE");

                DetailInvoice detailInvoice = new DetailInvoice(invoiceDetailDTO);
                detailInvoice.Dock = DockStyle.Top;
                this.Height = this.Height + detailInvoice.Height;
                panel5.Controls.Add(detailInvoice);
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbExit_MouseHover(object sender, EventArgs e)
        {
            lbExit.ForeColor = Color.Red;
            Cursor = Cursors.Hand;
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            lbExit.ForeColor = Color.Black;
            Cursor = Cursors.Default;
        }

        //// DI CHUYỂN TRÊN FORM
        
        private Point mouseOffset;
        private bool isDragging = false;

        private void Moving_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isDragging = true;
            }
        }

        private void Moving_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void Moving_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
