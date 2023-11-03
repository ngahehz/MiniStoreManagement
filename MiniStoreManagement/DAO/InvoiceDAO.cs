using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class SalesInvoiceDAO
    {
        internal static ConnectSQL conn = new ConnectSQL();
        public DataTable getInvoice()
        {
            return conn.ReadData("SELECT * FROM sales_invoice");
        }

        public bool addInvoice(SalesInvoiceDTO invoice)
        {
            string temp;
            if (invoice.VoucherId == null)
                temp = "NULL";
            else temp = invoice.VoucherId.ToString(); 
            string s = $"INSERT INTO sales_invoice VALUES ('{invoice.Id}', '{invoice.EmployeeId}','{invoice.Date}','{invoice.TotalPayment}','{invoice.ConsumerId}',{temp})";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateInvoice(SalesInvoiceDTO invoice)
        {
            string s = $"UPDATE sales_invoice SET ID = '{invoice.Id}', EMPLOYEE_ID = '{invoice.EmployeeId}', DATE = '{invoice.Date}', TOTAL_PAYMENT = '{invoice.TotalPayment}',"
                        + $"CONSUMER_ID = '{invoice.ConsumerId}', VOUCHER_ID = '{invoice.VoucherId}' WHERE id = '{invoice.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeInvoice(string id)
        {
            string s = $"DELETE FROM sales_invoice WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
    
    public class PurchaseInvoiceDAO
    {
        internal static ConnectSQL conn = new ConnectSQL();
        public DataTable getInvoice()
        {
            return conn.ReadData("SELECT * FROM purchase_invoice");
        }

        public bool addInvoice(PurchaseInvoiceDTO invoice)
        {
            string s = $"INSERT INTO purchase_invoice VALUES ('{invoice.Id}', '{invoice.EmployeeId}','{invoice.Date}','{invoice.TotalPayment}','{invoice.ProviderId}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateInvoice(PurchaseInvoiceDTO invoice)
        {
            string s = $"UPDATE purchase_invoice SET ID = '{invoice.Id}', EMPLOYEE_ID = '{invoice.EmployeeId}', DATE = '{invoice.Date}',"
                        + $"TOTAL_PAYMENT = '{invoice.TotalPayment}', NAME = '{invoice.ProviderId}' WHERE id = '{invoice.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeInvoice(string id)
        {
            string s = $"DELETE FROM purchase_invoice WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }

}
