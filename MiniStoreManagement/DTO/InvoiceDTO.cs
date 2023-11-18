using MiniStoreManagement.GUI.FormSP;
using MiniStoreManagement.GUI.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public SalesInvoiceDTO(DataRow row)
        {
            Id = row[0].ToString();
            EmployeeId = row[1].ToString();
            Date = DateTime.Parse(row[2].ToString());
            TotalPayment = decimal.Parse(row[3].ToString());
            ConsumerId = row[4].ToString();
            VoucherId = row[5].ToString();
            State = row[6].ToString();
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
        public PurchaseInvoiceDTO(DataRow row)
        {
            Id = row[0].ToString();
            EmployeeId = row[1].ToString();
            Date = DateTime.Parse(row[2].ToString());
            TotalPayment = decimal.Parse(row[3].ToString());
            ProviderId = row[4].ToString();
            State = row[5].ToString();
        }
    }
}
