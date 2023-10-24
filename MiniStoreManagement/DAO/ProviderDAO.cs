using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class ProviderDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getProvider()
        {
            return conn.ReadData("SELECT * FROM provider");
        }

        public bool addProvider(ProviderDTO provider)
        {
            string s = $"INSERT INTO provider VALUES ('{provider.Id}', '{provider.Name}','{provider.Cell}','{provider.Address}','{provider.Email}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateProvider(ProviderDTO provider)
        {
            string s = $"UPDATE provider SET ID = '{provider.Id}', NAME = '{provider.Name}', CELL = '{provider.Cell}', ADDRESS = '{provider.Address}',"
                        + $" EMAIL = '{provider.Email}' WHERE ID = '{provider.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeProvider(string id)
        {
            string s = $"DELETE FROM provider WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
