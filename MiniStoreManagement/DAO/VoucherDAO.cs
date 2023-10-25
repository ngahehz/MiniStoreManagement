using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string s = $"INSERT INTO voucher VALUES ('{voucher.Id}', '{voucher.Code}','{voucher.Discription}','{voucher.DiscountAmount}','{voucher.MinInvoiceValue}',"
                    + $"'{voucher.PercentDiscount}', '{voucher.MaxDiscount}','{voucher.StartDate}','{voucher.EndDate}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateVoucher(VoucherDTO voucher)
        {
            string s = $"UPDATE voucher SET ID = '{voucher.Id}', CODE = '{voucher.Code}', DISCRIPTION = '{voucher.Discription}', DISCOUNT_AMOUNT = '{voucher.DiscountAmount}',"
                    + $" MIN_INVOICE_VALUE = '{voucher.MinInvoiceValue}', PERCENT_DISCOUNT = '{voucher.PercentDiscount}', MAX_DISCOUNT = '{voucher.MaxDiscount}'"
                    + $" START_DATE = '{voucher.StartDate}', END_DATE = '{voucher.EndDate}' WHERE ID = '{voucher.Id}'";
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
