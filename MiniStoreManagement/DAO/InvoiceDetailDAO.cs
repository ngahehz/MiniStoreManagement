using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class SalesInvoiceDetailDAO
    {
        internal static ConnectSQL conn = new ConnectSQL();
        public DataTable getInvoice()
        {
            return conn.ReadData("SELECT * FROM sales_invoice_detail");
        }

        public bool addInvoiceDetail(SalesInvoiceDetailDTO invoiceDetail)
        {
            string s = $"INSERT INTO sales_invoice_detail VALUES ('{invoiceDetail.InvoiceId}', '{invoiceDetail.ProductId}','{invoiceDetail.Quantity}','{invoiceDetail.Price}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateInvoiceDetail (SalesInvoiceDetailDTO invoiceDetail)
        {
            string s = $"UPDATE sales_invoice_detail SET INVOICE_ID = '{invoiceDetail.InvoiceId}', PRODUCT_ID = '{invoiceDetail.ProductId}',"
                        + $"QUANTITY = '{invoiceDetail.Quantity}', PRICE = '{invoiceDetail.Price}' WHERE INVOICE_ID = '{invoiceDetail.InvoiceId}' AND PRODUCT_ID = '{invoiceDetail.ProductId}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeInvoiceDetail(string invoice_id, string product_id)
        {
            string s = $"DELETE FROM sales_invoice_detail WHERE INVOICE_ID = '{invoice_id}' AND PRODUCT_ID = '{product_id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }

    internal class PurchaseInvoiceDetailDAO
    {
        internal static ConnectSQL conn = new ConnectSQL();
        public DataTable getInvoice()
        {
            return conn.ReadData("SELECT * FROM purchase_invoice_detail");
        }

        public bool addInvoiceDetail(PurchaseInvoiceDetailDTO invoiceDetail)
        {
            string s = $"INSERT INTO purchase_invoice_detail VALUES ('{invoiceDetail.InvoiceId}', '{invoiceDetail.ProductId}','{invoiceDetail.Quantity}','{invoiceDetail.Price}','{invoiceDetail.Exp}','{invoiceDetail.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateInvoiceDetail(PurchaseInvoiceDetailDTO invoiceDetail)
        {
            string s = $"UPDATE purchase_invoice_detail SET INVOICE_ID = '{invoiceDetail.InvoiceId}', PRODUCT_ID = '{invoiceDetail.ProductId}', QUANTITY = '{invoiceDetail.Quantity}',"
                        + $"PRICE = '{invoiceDetail.Price}', EXP = '{invoiceDetail.Exp}', STATE = '{invoiceDetail.State}' WHERE INVOICE_ID = '{invoiceDetail.InvoiceId}' AND PRODUCT_ID = '{invoiceDetail.ProductId}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeInvoiceDetail(string invoice_id, string product_id)
        {
            string s = $"DELETE FROM purchase_invoice_detail WHERE INVOICE_ID = '{invoice_id}' AND PRODUCT_ID = '{product_id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
