using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class CategoryDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getCategory()
        {
            return conn.ReadData("SELECT * FROM category");
        }

        public bool addCategory(CategoryDTO category)
        {
            string s = $"INSERT INTO category VALUES ('{category.Id}', '{category.Name}', '{category.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateCategory(CategoryDTO category)
        {
            string s = $"UPDATE category SET ID = '{category.Id}', NAME = '{category.Name}',"
                        + $"STATE = '{category.State}' WHERE ID = '{category.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeCategory(string id)
        {
            string s = $"DELETE FROM category WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
