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
            string s = $"INSERT INTO provider VALUES ('{provider.Id}', N'{provider.Name}', '{provider.Cell}', N'{provider.Address}', '{provider.Email}', '{provider.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateProvider(ProviderDTO provider)
        {
            string s = $"UPDATE provider SET ID = '{provider.Id}', NAME = N'{provider.Name}', CELL = '{provider.Cell}', ADDRESS = N'{provider.Address}',"
                        + $" EMAIL = '{provider.Email}', STATE = '{provider.State}' WHERE ID = '{provider.Id}'";
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
