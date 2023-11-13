using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class InvoiceDTO
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public static double VAT { get; set; }
        public decimal TotalPayment { get; set; }
        public string State { get; set; } // 0 là trong quá trình tạo, 1 là đã tạo xong, 2 là xóa tạm
        public InvoiceDTO()
        {
            State = "0";
        }
        public InvoiceDTO(string id, string employeeId, DateTime date, decimal totalPayment, string state)
        {
            Id = id;
            EmployeeId = employeeId;
            Date = date;
            TotalPayment = totalPayment;
            State = state;
        }
    }

    public class SalesInvoiceDTO : InvoiceDTO
    {
        public string ConsumerId { get; set; }
        public string VoucherId { get; set; }
        public SalesInvoiceDTO() : base() { }
        public SalesInvoiceDTO(string id, string employeeId, DateTime date, decimal totalPayment, string state, string consumerId, string voucherId) : base (id, employeeId, date, totalPayment, state)
        {
            ConsumerId = consumerId;
            VoucherId = voucherId;
        }
    }

    public class PurchaseInvoiceDTO : InvoiceDTO
    {
        public string ProviderId { get; set; }
        public PurchaseInvoiceDTO() : base() { }
        public PurchaseInvoiceDTO(string id, string employeeId, DateTime date, decimal totalPayment, string state, string providerId) : base(id, employeeId, date, totalPayment, state)
        {
            ProviderId = providerId;
        }
    }
}
