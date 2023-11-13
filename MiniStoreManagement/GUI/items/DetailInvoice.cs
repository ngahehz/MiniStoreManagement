using MiniStoreManagement.BUS;
using MiniStoreManagement.DAO;
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
    public partial class DetailInvoice : UserControl
    {
        private ProductBUS productBUS = new ProductBUS();
        public DetailInvoice(InvoiceDetailDTO invoiceDetailDTO)
        {
            InitializeComponent();
            show(invoiceDetailDTO);
        }

        public void show(InvoiceDetailDTO invoiceDetailDTO)
        {
            if (ProductBUS.ProductList == null)
            {
                productBUS.getProduct();
            }

            DataRow row = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(r => r.Field<string>("ID") == invoiceDetailDTO.ProductId);

            if (row != null)
            {
                label1.Text = row["NAME"].ToString();
                label4.Text = invoiceDetailDTO.Quantity.ToString();
                label3.Text = row.Field<decimal>("PRICE").ToString("#,##0");
                label2.Text = (row.Field<decimal>("PRICE") * int.Parse(label4.Text)).ToString("#,##0");
                if(label1.Width > 150)
                {
                    this.Height = this.Height + label1.Height;
                    label1.MaximumSize = new Size(150, label1.Height*2);
                }
            }
        }
    }
}
