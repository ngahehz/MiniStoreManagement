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
    internal class AdminBUS
    {
        private static AdminDAO AdminDAO = new AdminDAO();
        public static DataTable AdminList;

        public void getAdmin()
        {
            AdminList = AdminDAO.getAdmin();
        }

        public bool checkAdmin(string user, string pass)
        {
            DataRow[] foundRows = AdminList.Select("USERNAME = '" + user + "'AND PASSWORD = '" + pass + "'");
            if (foundRows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addAdmin(AdminDTO admin)
        {
            if (AdminDAO.addAdmin(admin))
                return true;
            return false;
        }

        public bool updateAdmin(AdminDTO admin)
        {
            if (AdminDAO.updateAdmin(admin))
                return true;
            return false;
        }

        public bool removeAdmin(string id)
        {
            if (AdminDAO.removeAdmin(id))
                return true;
            return false;
        }
    }
}
