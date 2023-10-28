using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public static double VAT { get; set; }
        public decimal TotalPayment { get; set; }
        public InvoiceDTO() { }
        public InvoiceDTO(int id, int employeeId, DateTime date, decimal totalPayment) { 
            Id = id;
            EmployeeId = employeeId;
            Date = date;
            TotalPayment = totalPayment;
        }
    }

    public class SalesInvoiceDTO : InvoiceDTO
    {
        public int ConsumerId { get; set; }
        public int? VoucherId { get; set; }
        public SalesInvoiceDTO() { }
        public SalesInvoiceDTO(int id, int employeeId, DateTime date, decimal totalPayment, int consumerId, int voucherId) : base (id, employeeId, date, totalPayment)
        {
            ConsumerId = consumerId;
            VoucherId = voucherId;
        }
    }

    public class PurchaseInvoiceDTO : InvoiceDTO
    {
        public int ProviderId { get; set; }
        public PurchaseInvoiceDTO() { }
        public PurchaseInvoiceDTO(int id, int employeeId, DateTime date, decimal totalPayment, int providerId) : base(id, employeeId, date, totalPayment)
        {
            ProviderId = providerId;
        }
    }
}
