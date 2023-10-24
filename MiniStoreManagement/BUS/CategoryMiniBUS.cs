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
    internal class CategoryMiniBUS
    {
        private static CategoryMiniDAO CategoryMiniDAO = new CategoryMiniDAO();
        public static DataTable CategoryMiniList;

        public void getCategoryMini()
        {
            CategoryMiniList = CategoryMiniDAO.getCategoryMini();
        }
        public bool addCategoryMini(CategoryMiniDTO categoryMini)
        {
            if (CategoryMiniDAO.addCategoryMini(categoryMini))
                return true;
            return false;
        }
        public bool updateCategoryMini(CategoryMiniDTO categoryMini)
        {
            if (CategoryMiniDAO.updateCategoryMini(categoryMini))
                return true;
            return false;
        }
        public bool removeCategoryMini(string id)
        {
            if (CategoryMiniDAO.removeCategoryMini(id))
                return true;
            return false;
        }
    }
}
