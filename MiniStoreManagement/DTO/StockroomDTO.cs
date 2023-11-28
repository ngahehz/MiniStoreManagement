using MiniStoreManagement.GUI.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniStoreManagement.DTO
{
    internal class StockroomDTO
    {
        public string ID { get; set; }
        public string PRODUCT_ID { get; set; }
        public int QUANTITY { get; set; }
        public DateTime EXP { get; set; }
        public StockroomDTO() { }
        public StockroomDTO(DataRow row)
        {
            ID = row[0].ToString();
            PRODUCT_ID = row[1].ToString();
            QUANTITY = (int)row[2];
            EXP = (DateTime)row[3];
        }
    }
}
