using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class StockroomDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getStockroom()
        {
            return conn.ReadData("SELECT * FROM stockroom");
        }

        public bool addStockroom(StockroomDTO stockroom)
        {
            string s = $"INSERT INTO stockroom VALUES ('{stockroom.ID}', '{stockroom.PRODUCT_ID}', '{stockroom.QUANTITY}', '{stockroom.EXP}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateStockroom(StockroomDTO stockroom)
        {
            string s = $"UPDATE stockroom SET ID = '{stockroom.ID}', PRODUCT_ID = '{stockroom.PRODUCT_ID}', QUANTITY = '{stockroom.QUANTITY}', "
                        + $" EXP = '{stockroom.EXP}' WHERE ID = '{stockroom.ID}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeStockroom(string id)
        {
            string s = $"DELETE FROM stockroom WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
