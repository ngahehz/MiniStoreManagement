using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int PromotionId { get; set; }
        public int ProviderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Exp { get; set; }
        public string Img { get; set; }
        public ProductDTO()
        {
            
        }
        public ProductDTO(int id, string name, int categoryId, int promotionId, int providerId, decimal price, int quantity, DateTime exp, string img)
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

        }
    }
}
