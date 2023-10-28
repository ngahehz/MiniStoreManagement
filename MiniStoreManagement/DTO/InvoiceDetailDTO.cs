using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class SalesInvoiceDetailDTO
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public SalesInvoiceDetailDTO() { }
        public SalesInvoiceDetailDTO(int invoiceId, int productId, int quantity)
        {
            InvoiceId = invoiceId;
            ProductId = productId;
            Quantity = quantity;
        }
    }

    //public class SalesInvoiceDetailsDTO : InvoiceDetailsDTO
    //{
    //    public int ConsumerId { get; set; }
    //    public SalesInvoiceDetailsDTO(int id, int productId, int quantity, double price) : base (id, productId, quantity)
    //    {
    //        ConsumerId = consumerId;
    //    }
    //}

    public class PurchaseInvoiceDetailDTO : SalesInvoiceDetailDTO
    {
        public decimal Price { get; set; }
        public PurchaseInvoiceDetailDTO() { }
        public PurchaseInvoiceDetailDTO(int invoiceId, int productId, int quantity, decimal price) : base (invoiceId, productId, quantity)
        {
            Price = price;
        }
    }
}
