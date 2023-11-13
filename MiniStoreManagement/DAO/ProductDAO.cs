using MiniStoreManagement.DTO;
using MiniStoreManagement.GUI.items;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class ProductDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getProduct()
        {
            return conn.ReadData("SELECT * FROM product");
        }

        public bool addProduct(ProductDTO product)
        {
            string s = $"INSERT INTO product VALUES ('{product.Id}', '{product.Name}','{product.CategoryId}','{product.PromotionId}','{product.ProviderId}','{product.Price}','{product.Quantity}','{product.Exp}','{product.Img}','{product.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateProduct(ProductDTO product)
        {
            string s = $"UPDATE product SET ID = '{product.Id}', NAME = '{product.Name}', CATEGORY_ID = '{product.CategoryId}', PROMOTION_ID = '{product.PromotionId}',"
                   + $" PROVIDER_ID = '{product.ProviderId}', PRICE = '{product.Price}', QUANTITY = '{product.Quantity}',"
                   + $" EXP = '{product.Exp}', IMG = '{product.Img}', STATE = '{product.State}' WHERE ID = '{product.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeProduct(string id)
        {
            string s = $"DELETE FROM product WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
