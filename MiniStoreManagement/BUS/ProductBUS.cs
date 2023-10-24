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
    internal class ProductBUS
    {
        private static ProductDAO ProductDAO = new ProductDAO();
        public static DataTable ProductList;

        public void getProduct()
        {
            ProductList = ProductDAO.getProduct();
        }
        public bool addProduct(ProductDTO product)
        {
            if (ProductDAO.addProduct(product))
                return true;
            return false;
        }
        public bool updateProduct(ProductDTO product)
        {
            if (ProductDAO.updateProduct(product))
                return true;
            return false;
        }
        public bool removeProduct(string id)
        {
            if (ProductDAO.removeProduct(id))
                return true;
            return false;
        }
    }
}
