using System;
using System.Collections.Generic;
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
        public ProductDTO(string id, string name, string categoryId, string promotionId, string providerId, decimal price, int quantity, DateTime exp, string img, string state)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            PromotionId = promotionId;
            ProviderId = providerId;
            Price = price;
            Quantity = quantity;
            Exp = exp;
            Img = img;
            State = state;
        }
    }
}
