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
    internal class ProviderBUS
    {
        private static ProviderDAO ProviderDAO = new ProviderDAO();
        public static DataTable ProviderList;

        public void getProvider()
        {
            ProviderList = ProviderDAO.getProvider();
        }
        public bool addProvider(ProviderDTO provider)
        {
            if (ProviderDAO.addProvider(provider))
                return true;
            return false;
        }
        public bool updateProvider(ProviderDTO provider)
        {
            if (ProviderDAO.updateProvider(provider))
                return true;
            return false;
        }
        public bool removeProvider(string id)
        {
            if (ProviderDAO.removeProvider(id))
                return true;
            return false;
        }
    }
}
