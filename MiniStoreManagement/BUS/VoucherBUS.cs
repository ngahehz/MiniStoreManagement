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
    internal class VoucherBUS
    {
        private static VoucherDAO VoucherDAO = new VoucherDAO();
        public static DataTable VoucherList;

        public void getVoucher()
        {
            VoucherList = VoucherDAO.getVoucher();
        }
        public bool addVoucher(VoucherDTO voucher)
        {
            if (VoucherDAO.addVoucher(voucher))
                return true;
            return false;
        }
        public bool updateVoucher(VoucherDTO voucher)
        {
            if (VoucherDAO.updateVoucher(voucher))
                return true;
            return false;
        }
        public bool removeVoucher(string id)
        {
            if (VoucherDAO.removeVoucher(id))
                return true;
            return false;
        }
    }
}
