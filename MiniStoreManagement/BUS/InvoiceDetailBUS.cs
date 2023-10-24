using MiniStoreManagement.DAO;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.BUS
{
    internal class SalesInvoiceDetailBUS
    {
        private static SalesInvoiceDetailDAO SalesInvoiceDAO = new SalesInvoiceDetailDAO();
        public static DataTable SalesInvoiceDetailList;

        public void getInvoiceDetail()
        {
            SalesInvoiceDetailList = SalesInvoiceDAO.getInvoice();
        }
        public bool addInvoiceDetail(SalesInvoiceDetailDTO invoiceDetail)
        {
            if (SalesInvoiceDAO.addInvoiceDetail(invoiceDetail))
                return true;
            return false;
        }
        public bool updateInvoiceDetail(SalesInvoiceDetailDTO invoiceDetail)
        {
            if (SalesInvoiceDAO.updateInvoiceDetail(invoiceDetail))
                return true;
            return false;
        }
        public bool removeInvoiceDetail(string invoice_id, string product_id)
        {
            if (SalesInvoiceDAO.removeInvoiceDetail(invoice_id, product_id))
                return true;
            return false;
        }
    }

    internal class PurchaseInvoiceDetailBUS
    {
        private static PurchaseInvoiceDetailDAO PurchaseInvoiceDAO = new PurchaseInvoiceDetailDAO();
        public static DataTable PurchaseInvoiceDetailList;

        public void getInvoiceDetail()
        {
            PurchaseInvoiceDetailList = PurchaseInvoiceDAO.getInvoice();
        }
        public bool addInvoiceDetail(PurchaseInvoiceDetailDTO invoiceDetail)
        {
            if (PurchaseInvoiceDAO.addInvoiceDetail(invoiceDetail))
                return true;
            return false;
        }
        public bool updateInvoiceDetail(PurchaseInvoiceDetailDTO invoiceDetail)
        {
            if (PurchaseInvoiceDAO.updateInvoiceDetail(invoiceDetail))
                return true;
            return false;
        }
        public bool removeInvoiceDetail(string invoice_id, string product_id)
        {
            if (PurchaseInvoiceDAO.removeInvoiceDetail(invoice_id, product_id))
                return true;
            return false;
        }
    }
}
