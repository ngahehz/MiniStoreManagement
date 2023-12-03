using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class SalesInvoiceDetailDTO
    {
        public string InvoiceId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public SalesInvoiceDetailDTO() { }
    }

    public class PurchaseInvoiceDetailDTO : SalesInvoiceDetailDTO
    {
        public DateTime Exp { get; set; }
        public PurchaseInvoiceDetailDTO() : base() { }

        //public PurchaseInvoiceDetailDTO(DataRow row)
        //{
        //    Id = row[0].ToString();
        //    EmployeeId = row[1].ToString();
        //    Date = DateTime.Parse(row[2].ToString());
        //    TotalPayment = decimal.Parse(row[3].ToString());
        //    ProviderId = row[4].ToString();
        //}
    }

}
