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
    internal class PromotionBUS
    {
        private static PromotionDAO PromotionDAO = new PromotionDAO();
        public static DataTable PromotionList;

        public void getPromotion()
        {
            PromotionList = PromotionDAO.getPromotion();
        }
        public bool addPromotion(PromotionDTO promotion)
        {
            if (PromotionDAO.addPromotion(promotion))
                return true;
            return false;
        }
        public bool updatePromotion(PromotionDTO promotion)
        {
            if (PromotionDAO.updatePromotion(promotion))
                return true;
            return false;
        }
        public bool removePromotion(string id)
        {
            if (PromotionDAO.removePromotion(id))
                return true;
            return false;
        }
    }
}
