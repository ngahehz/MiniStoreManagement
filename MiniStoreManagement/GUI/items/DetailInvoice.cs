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
        public DetailInvoice(SalesInvoiceDetailDTO salesInvoiceDetailDTO)
        {
            InitializeComponent();
            show(salesInvoiceDetailDTO);
        }

        public void show(SalesInvoiceDetailDTO salesInvoiceDetailDTO)
        {
            if (ProductBUS.ProductList == null)
            {
                productBUS.getProduct();
            }

            DataRow row = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(r => r.Field<int>("ID") == salesInvoiceDetailDTO.ProductId);

            if (row != null)
            {
                label1.Text = row["NAME"].ToString();
                label4.Text = salesInvoiceDetailDTO.Quantity.ToString();
                label3.Text = row["PRICE"].ToString();
                label2.Text = (int.Parse(label3.Text) * int.Parse(label4.Text)).ToString();
                if(label1.Width > 150)
                {
                    this.Height = this.Height + label1.Height;
                    label1.MaximumSize = new Size(150, label1.Height*2);
                }
            }
        }
    }
}
