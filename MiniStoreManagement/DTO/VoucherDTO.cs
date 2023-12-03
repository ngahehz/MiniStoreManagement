using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.DTO
{
    internal class VoucherDTO
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Discription { get; set; }
        public decimal? DiscountAmount { get; set; } // giá giảm
        public decimal? MinInvoiceValue { get; set; } // giá trị đơn hàng tối thiểu
        public double? PercentDiscount { get; set; } // % giảm
        public decimal? MaxDiscount { get; set; } //  giảm tối đa

        // có 1 trong 2 cặp trên thôi
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State {  get; set; }
        public VoucherDTO()
        {
            State = "0";
        }
        public VoucherDTO(DataRow row)
        {
            Id = row[0].ToString();
            Code = row[1].ToString();
            Discription = row[2].ToString();

            if (string.IsNullOrEmpty(row[3].ToString()))
                DiscountAmount = null;
            else
                DiscountAmount = (decimal?)row[3];

            if (string.IsNullOrEmpty(row[4].ToString()))
                MinInvoiceValue = null;
            else
                MinInvoiceValue = (decimal?)row[4];

            if (string.IsNullOrEmpty(row[5].ToString()))
                PercentDiscount = null;
            else
                PercentDiscount = (double?)row[5];

            if (string.IsNullOrEmpty(row[6].ToString()))
                MaxDiscount = null;
            else
                MaxDiscount = (decimal?)row[6];

            StartDate = (DateTime)row[7];
            EndDate = (DateTime)row[8];
            State = row[9].ToString();

        }
    }
}
