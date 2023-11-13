using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class InvoiceDetailDTO
    {
        public string InvoiceId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public InvoiceDetailDTO() { }
        public InvoiceDetailDTO(string invoiceId, string productId, int quantity, decimal price)
        {
            InvoiceId = invoiceId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }

}
