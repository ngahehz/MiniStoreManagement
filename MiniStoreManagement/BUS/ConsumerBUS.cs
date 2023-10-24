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
    internal class ConsumerBUS
    {
        private static ConsumerDAO ConsumerDAO = new ConsumerDAO();
        public static DataTable ConsumerList;

        public void getConsumer()
        {
            ConsumerList = ConsumerDAO.getConsumer();
        }
        public bool addConsumer(ConsumerDTO consumer)
        {
            if (ConsumerDAO.addConsumer(consumer))
                return true;
            return false;
        }
        public bool updateConsumer(ConsumerDTO consumer)
        {
            if (ConsumerDAO.updateConsumer(consumer))
                return true;
            return false;
        }
        public bool removeConsumer(string id)
        {
            if (ConsumerDAO.removeConsumer(id))
                return true;
            return false;
        }
    }
}
