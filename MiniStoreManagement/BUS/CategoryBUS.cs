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
    internal class CategoryBUS
    {
        private static CategoryDAO CategoryDAO = new CategoryDAO();
        public static DataTable CategoryList;

        public void getCategory()
        {
            CategoryList = CategoryDAO.getCategory();
        }
        public bool addCategory(CategoryDTO category)
        {
            if (CategoryDAO.addCategory(category))
                return true;
            return false;
        }
        public bool updateCategory(CategoryDTO category)
        {
            if (CategoryDAO.updateCategory(category))
                return true;
            return false;
        }
        public bool removeCategory(string id)
        {
            if (CategoryDAO.removeCategory(id))
                return true;
            return false;
        }
    }
}
