using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class CategoryMiniDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getCategoryMini()
        {
            return conn.ReadData("SELECT * FROM category_mini");
        }

        public bool addCategoryMini(CategoryMiniDTO categoryMini)
        {
            string s = $"INSERT INTO category_mini VALUES ('{categoryMini.Id}', '{categoryMini.Name}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateCategoryMini(CategoryMiniDTO categoryMini)
        {
            string s = $"UPDATE category_mini SET ID = '{categoryMini.Id}', NAME = '{categoryMini.Name}',"
                        + $" WHERE ID = '{categoryMini.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeCategoryMini(string id)
        {
            string s = $"DELETE FROM category_mini WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
