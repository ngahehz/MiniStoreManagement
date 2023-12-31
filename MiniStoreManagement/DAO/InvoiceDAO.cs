﻿using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string con_id;
            string vou_id;

            if (string.IsNullOrWhiteSpace(invoice.ConsumerId))
                con_id = "NULL";
            else
                con_id = invoice.ConsumerId;

            if (string.IsNullOrWhiteSpace(invoice.VoucherId))
                vou_id = "NULL";
            else
                vou_id = invoice.VoucherId;

            string s = $"INSERT INTO sales_invoice VALUES ('{invoice.Id}', '{invoice.EmployeeId}', '{invoice.Date}', '{invoice.TotalPayment}', {con_id}, {vou_id}, '{invoice.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateInvoice(SalesInvoiceDTO invoice)
        {
            string con_id;
            string vou_id;

            if (string.IsNullOrWhiteSpace(invoice.ConsumerId))
                con_id = "NULL";
            else
                con_id = invoice.ConsumerId;

            if (string.IsNullOrWhiteSpace(invoice.VoucherId))
                vou_id = "NULL";
            else
                vou_id = invoice.VoucherId;

            string s = $"UPDATE sales_invoice SET ID = '{invoice.Id}', EMPLOYEE_ID = '{invoice.EmployeeId}', DATE = '{invoice.Date}', TOTAL_PAYMENT = '{invoice.TotalPayment}',"
                        + $"CONSUMER_ID = {con_id}, VOUCHER_ID = {vou_id}, STATE = '{invoice.State}' WHERE id = '{invoice.Id}'";
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
            string s = $"INSERT INTO purchase_invoice VALUES ('{invoice.Id}', '{invoice.EmployeeId}','{invoice.Date}','{invoice.TotalPayment}','{invoice.ProviderId}', '{invoice.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateInvoice(PurchaseInvoiceDTO invoice)
        {
            string s = $"UPDATE purchase_invoice SET ID = '{invoice.Id}', EMPLOYEE_ID = '{invoice.EmployeeId}', DATE = '{invoice.Date}',"
                        + $"TOTAL_PAYMENT = '{invoice.TotalPayment}', PROVIDER_ID = '{invoice.ProviderId}', STATE = '{invoice.State}' WHERE id = '{invoice.Id}'";
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
