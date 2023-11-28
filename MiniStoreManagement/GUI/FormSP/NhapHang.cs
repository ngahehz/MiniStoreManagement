using MiniStoreManagement.BUS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.FormSP
{
    public partial class NhapHang : Form
    {
        private PurchaseInvoiceBUS purchaseInvoiceBUS = new PurchaseInvoiceBUS();
        private PurchaseInvoiceDetailBUS purchaseInvoiceDetailBUS = new PurchaseInvoiceDetailBUS();
        private string product_id;
        List<string[]> gidoList = new List<string[]>();
        public NhapHang(string id)
        {
            InitializeComponent();
            product_id = id;
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            if (PurchaseInvoiceBUS.PurchaseInvoiceList == null)
                purchaseInvoiceBUS.getInvoice();
            if (PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList == null)
                purchaseInvoiceDetailBUS.getInvoiceDetail();

            var gido = from ct in PurchaseInvoiceDetailBUS.PurchaseInvoiceDetailList.AsEnumerable()
                       join h in PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable() on ct.Field<string>("INVOICE_ID") equals h.Field<string>("ID")
                       where ct.Field<string>("PRODUCT_ID") == product_id
                       select new
                       {
                           NGAY_NHAP = h.Field<DateTime>("DATE"),
                           ID_HOADON = ct.Field<string>("INVOICE_ID"),
                           ID_SANPHAM = ct.Field<string>("PRODUCT_ID"),
                           QUANTITY = ct.Field<int>("QUANTITY"),
                           PRICE = ct.Field<decimal>("PRICE"),
                           EXP = ct.Field<DateTime>("EXP")
                       };

            foreach (var item in gido)
            {
                //gidoList.Add
                //{
                //    item.ID_HOADON.ToString(),
                //    item.ID_SANPHAM.ToString(),
                //    item.QUANTITY.ToString(),
                //    item.PRICE.ToString();
                //    item.EXP.ToString()
                //};

                string[] detailArray = {
                    item.ID_HOADON,
                    item.ID_SANPHAM,
                    item.QUANTITY.ToString(),
                    item.PRICE.ToString(),
                    item.EXP.ToString("dd/MM/yyyy")
                };

                gidoList.Add(detailArray);

                cbbDate.Items.Add(item.NGAY_NHAP.ToString("dd/MM/yyyy"));
            }
        }

        private void cbbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbDate.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < gidoList.Count)
            {
                string[] selectedDetail = gidoList[selectedIndex];

                lb1.Text = selectedDetail[0];
                lb2.Text = selectedDetail[1];
                lb3.Text = selectedDetail[2];
                lb4.Text = selectedDetail[3];
                lb5.Text = selectedDetail[4];
            }

        }
    }

}
