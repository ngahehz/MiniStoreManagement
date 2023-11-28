using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DAO
{
    internal class PromotionDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getPromotion()
        {
            return conn.ReadData("SELECT * FROM promotion");
        }

        public bool addPromotion(PromotionDTO promotion)
        {
            string s = $"INSERT INTO promotion VALUES ('{promotion.Id}', N'{promotion.Discription}', '{promotion.PercentDiscount}', '{promotion.StartDate}', '{promotion.EndDate}', '{promotion.State}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updatePromotion(PromotionDTO promotion)
        {
            string s = $"UPDATE promotion SET ID = '{promotion.Id}', DISCRIPTION = N'{promotion.Discription}', PERCENT_DISCOUNT = '{promotion.PercentDiscount}', "
                        + $"START_DATE = '{promotion.StartDate}', END_DATE = '{promotion.EndDate}', STATE = '{promotion.State}' WHERE ID = '{promotion.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removePromotion(string id)
        {
            string s = $"DELETE FROM promotion WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }
    }
}
