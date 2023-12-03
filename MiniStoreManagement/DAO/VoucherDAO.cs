using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.items;
using MiniStoreManagement.GUI.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MiniStoreManagement.DAO
{
    internal class VoucherDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getVoucher()
        {
            return conn.ReadData("SELECT * FROM voucher");
        }

        public bool addVoucher(VoucherDTO voucher)
        {
            string DiscountAmount;
            string MinInvoiceValue;
            string PercentDiscount;
            string MaxDiscount;

            if (voucher.DiscountAmount == null)
            {
                DiscountAmount = "NULL";
                MinInvoiceValue = "NULL";
                PercentDiscount = voucher.PercentDiscount.ToString();
                MaxDiscount = voucher.MaxDiscount.ToString();
            }
            else
            {
                DiscountAmount = voucher.DiscountAmount.ToString();
                MinInvoiceValue = voucher.MinInvoiceValue.ToString();
                PercentDiscount = "NULL";
                MaxDiscount = "NULL";
            }
               
            string s = $"INSERT INTO voucher VALUES ('{voucher.Id}', '{voucher.Code}', N'{voucher.Discription}', {DiscountAmount}, {MinInvoiceValue},"
                    + $" {PercentDiscount}, {MaxDiscount},'{voucher.StartDate}','{voucher.EndDate}','{voucher.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateVoucher(VoucherDTO voucher)
        {
            string DiscountAmount;
            string MinInvoiceValue;
            string PercentDiscount;
            string MaxDiscount;
            if (voucher.DiscountAmount == null)
            {
                DiscountAmount = "NULL";
                MinInvoiceValue = "NULL";
                PercentDiscount = voucher.PercentDiscount.ToString();
                MaxDiscount = voucher.MaxDiscount.ToString();
            }
            else
            {
                DiscountAmount = voucher.DiscountAmount.ToString();
                MinInvoiceValue = voucher.MinInvoiceValue.ToString();
                PercentDiscount = "NULL";
                MaxDiscount = "NULL";
            }
            string s = $"UPDATE voucher SET ID = '{voucher.Id}', CODE = '{voucher.Code}', DISCRIPTION = N'{voucher.Discription}', DISCOUNT_AMOUNT = {DiscountAmount}, "
                    + $" MIN_INVOICE_VALUE = {MinInvoiceValue}, PERCENT_DISCOUNT = {PercentDiscount}, MAX_DISCOUNT = {MaxDiscount}, "
                    + $" START_DATE = '{voucher.StartDate}', END_DATE = '{voucher.EndDate}', STATE = '{voucher.State}' WHERE ID = '{voucher.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeVoucher(string id)
        {
            string s = $"DELETE FROM voucher WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
