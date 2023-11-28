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
    internal class StockroomBUS
    {
        private static StockroomDAO StockroomDAO = new StockroomDAO();
        public static DataTable StockroomList;

        public void getStockroom()
        {
            StockroomList = StockroomDAO.getStockroom();
        }
        public bool addStockroom(StockroomDTO stockroom)
        {
            if (StockroomDAO.addStockroom(stockroom))
                return true;
            return false;
        }
        public bool updateStockroom(StockroomDTO stockroom)
        {
            if (StockroomDAO.updateStockroom(stockroom))
                return true;
            return false;
        }
        public bool removeStockroom(string id)
        {
            if (StockroomDAO.removeStockroom(id))
                return true;
            return false;
        }
    }
}
