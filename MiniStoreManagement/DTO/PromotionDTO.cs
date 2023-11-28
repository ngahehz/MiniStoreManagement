using MiniStoreManagement.GUI.UCs;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniStoreManagement.DTO
{
    public class PromotionDTO
    {
        public string Id { get; set; }
        public string Discription { get; set; }
        public double PercentDiscount { get; set; } // % giảm
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; }
        public PromotionDTO()
        {
            State = "0";
        }
        public PromotionDTO(DataRow row)
        {
            Id = row[0].ToString();
            Discription = row[1].ToString();
            PercentDiscount = (double)row[2];
            StartDate = (DateTime)row[3];
            EndDate = (DateTime)row[4];
            State = row[5].ToString();
        }
    }
}
