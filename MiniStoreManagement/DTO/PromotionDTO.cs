using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class PromotionDTO
    {
        public string Id { get; set; }
        public string Discription { get; set; }
        public decimal PercentDiscount { get; set; } // % giảm
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PromotionDTO()
        {

        }
        public PromotionDTO(string id, string discription, decimal percentDiscount, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Discription = discription;
            PercentDiscount = percentDiscount;
            StartDate = startDate;
            EndDate = endDate;

        }
    }
}
