using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class ConsumerDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getConsumer()
        {
            return conn.ReadData("SELECT * FROM consumer");
        }

        public bool addConsumer(ConsumerDTO consumer)
        {
            string s = $"INSERT INTO consumer VALUES ('{consumer.Id}', '{consumer.Name}','{consumer.Gender}','{consumer.DoB}','{consumer.Cell}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateConsumer(ConsumerDTO consumer)
        {
            string s = $"UPDATE consumer SET ID = '{consumer.Id}', NAME = '{consumer.Name}', GENDER = '{consumer.Gender}', DOB = '{consumer.DoB}',"
                        + $" CELL = '{consumer.Cell}' WHERE ID = '{consumer.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeConsumer(string id)
        {
            string s = $"DELETE FROM consumer WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
