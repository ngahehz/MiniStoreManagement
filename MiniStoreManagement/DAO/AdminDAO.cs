using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class AdminDAO
    {
        private static ConnectSQL conn = new ConnectSQL();
        public DataTable getAdmin()
        {
            return conn.ReadData("SELECT * FROM admin");
        }
        public bool addAdmin(AdminDTO admin)
        {
            string s = $"INSERT INTO admin VALUES ('{admin.ID}','{admin.USERNAME}','{admin.PASSWORD}','{admin.NAME}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateAdmin(AdminDTO admin)
        {
            string s = $"UPDATE admin SET PASSWORD = '{admin.PASSWORD}' Where USERNAME = '{admin.USERNAME}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeAdmin(string id)
        {
            string s = $"DELETE FROM admin WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
