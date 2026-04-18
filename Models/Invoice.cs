using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SweetShop.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int OrderID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

        // علاقات
        public Order? Order { get; set; }
    }

}
