using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string PromotionId { get; set; }
        public string ProviderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Exp { get; set; }
        public string Img { get; set; }
        public string State { get; set; } // 0 là bth, 1 là xóa tạm
        public ProductDTO()
        {
            State = "0";
        }
        public ProductDTO(DataRow row)
        {
            Id = row[0].ToString();
            Name = row[1].ToString();
            CategoryId = row[2].ToString();
            PromotionId = row[3].ToString();
            ProviderId = row[4].ToString();
            Price = (decimal)row[5];
            Quantity = (int)row[6];
            Exp = (DateTime)row[7];
            Img = row[8].ToString();
            State = row[9].ToString();
        }
    }
}
