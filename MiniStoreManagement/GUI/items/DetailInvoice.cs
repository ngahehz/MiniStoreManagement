﻿using MiniStoreManagement.BUS;
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
        public DetailInvoice(SalesInvoiceDetailDTO invoiceDetailDTO)
        {
            InitializeComponent();
            show(invoiceDetailDTO);
        }

        public void show(SalesInvoiceDetailDTO invoiceDetailDTO)
        {
            if (ProductBUS.ProductList == null)
            {
                productBUS.getProduct();
            }

            DataRow row_product = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(r => r.Field<string>("ID") == invoiceDetailDTO.ProductId);
            //DataRow row_promotion = PromotionBUS.PromotionList.AsEnumerable().FirstOrDefault(r => r.Field<string>("ID") == row_product[3].ToString());

            if (row_product != null)
            {
                label1.Text = row_product["NAME"].ToString();
                label4.Text = invoiceDetailDTO.Quantity.ToString();
                label3.Text = invoiceDetailDTO.Price.ToString("#,##0");
                label2.Text = (invoiceDetailDTO.Price * int.Parse(label4.Text)).ToString("#,##0");
                if (label1.Width > 150)
                {
                    this.Height = this.Height + label1.Height;
                    label1.MaximumSize = new Size(150, label1.Height * 2);
                }
            }
        }
    }
}
