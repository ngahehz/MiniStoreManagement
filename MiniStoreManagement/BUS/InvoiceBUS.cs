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
    internal class SalesInvoiceBUS
    {
        private static SalesInvoiceDAO SalesInvoiceDAO = new SalesInvoiceDAO();
        public static DataTable SalesInvoiceList;

        public void getInvoice()
        {
            SalesInvoiceList = SalesInvoiceDAO.getInvoice();
        }
        public bool addInvoice(SalesInvoiceDTO invoice)
        {
            if (SalesInvoiceDAO.addInvoice(invoice))
                return true;
            return false;
        }
        public bool updateInvoice(SalesInvoiceDTO invoice)
        {
            if (SalesInvoiceDAO.updateInvoice(invoice))
                return true;
            return false;
        }
        public bool removeInvoice(string id)
        {
            if (SalesInvoiceDAO.removeInvoice(id))
                return true;
            return false;
        }
    }

    internal class PurchaseInvoiceBUS
    {
        private static PurchaseInvoiceDAO PurchaseInvoiceDAO = new PurchaseInvoiceDAO();
        public static DataTable PurchaseInvoiceList;

        public void getInvoice()
        {
            PurchaseInvoiceList = PurchaseInvoiceDAO.getInvoice();
        }
        public bool addInvoice(PurchaseInvoiceDTO invoice)
        {
            if (PurchaseInvoiceDAO.addInvoice(invoice))
                return true;
            return false;
        }
        public bool updateInvoice(PurchaseInvoiceDTO invoice)
        {
            if (PurchaseInvoiceDAO.updateInvoice(invoice))
                return true;
            return false;
        }
        public bool removeInvoice(string id)
        {
            if (PurchaseInvoiceDAO.removeInvoice(id))
                return true;
            return false;
        }
    }
}
