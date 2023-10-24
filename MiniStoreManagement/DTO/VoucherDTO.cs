using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class VoucherDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Discription { get; set; }
        public decimal DiscountAmount { get; set; } // giá giảm
        public decimal MinInvoiceValue { get; set; } // giá trị đơn hàng tối thiểu
        public decimal PercentDiscount { get; set; } // % giảm
        public decimal MaxDiscount { get; set; } // % giảm tối đa

        // có 1 trong 2 cặp trên thôi
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VoucherDTO()
        {

        }
        public VoucherDTO(int id, string code, string discription, decimal discountAmount, decimal minInvoiceValue, decimal percentDiscount, decimal maxDiscount, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Code = code;
            Discription = discription;
            DiscountAmount = discountAmount;
            MinInvoiceValue = minInvoiceValue;
            PercentDiscount = percentDiscount;
            MaxDiscount = maxDiscount;
            StartDate = startDate;
            EndDate = endDate;           

        }
    }
}
