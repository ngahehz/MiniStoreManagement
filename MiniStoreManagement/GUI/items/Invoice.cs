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
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStoreManagement.GUI.items
{
    public partial class Invoice : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        public Invoice(SalesInvoiceDTO salesInvoiceDTO)
        {
            InitializeComponent();
            Details(salesInvoiceDTO);
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
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
            if (!string.IsNullOrWhiteSpace(salesInvoiceDTO.VoucherId))
            {
                newpn.Visible = true;
                this.Height += newpn.Height;
                lbKM.Text = salesInvoiceDTO.TotalPayment.ToString("#,##0");

                DataRow _row = VoucherBUS.VoucherList.AsEnumerable().FirstOrDefault(r => r.Field<string>("ID") == salesInvoiceDTO.VoucherId);
                lbTong2.Text = _row[2].ToString();
            }

            DataRow row = EmployeeBUS.EmployeeList.AsEnumerable().FirstOrDefault(r => r.Field<string>("ID") == salesInvoiceDTO.EmployeeId);
            lbEmployee.Text = lbEmployee.Text + row["NAME"];
            
            var find = SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable().Where(lane => lane.Field<string>("INVOICE_ID") == salesInvoiceDTO.Id);

            decimal payment = 0;
            foreach (var _row in find)
            {
                SalesInvoiceDetailDTO invoiceDetailDTO = new SalesInvoiceDetailDTO();
                invoiceDetailDTO.InvoiceId = _row.Field<string>("INVOICE_ID");
                invoiceDetailDTO.ProductId = _row.Field<string>("PRODUCT_ID");
                invoiceDetailDTO.Quantity = _row.Field<int>("QUANTITY");
                invoiceDetailDTO.Price = _row.Field<decimal>("PRICE");

                payment += invoiceDetailDTO.Price * invoiceDetailDTO.Quantity;
                DetailInvoice detailInvoice = new DetailInvoice(invoiceDetailDTO);
                detailInvoice.Dock = DockStyle.Top;
                this.Height = this.Height + detailInvoice.Height;
                panel5.Controls.Add(detailInvoice);
            }
            lbPayment.Text = payment.ToString("#,##0");
            
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

        private void lblin_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
       


        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);

        }




    }
}
