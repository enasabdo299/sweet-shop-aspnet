namespace SweetShop.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string?  Position { get; set; }
        public decimal? Salary { get; set; }

        // علاقات
        public ICollection<Order> ?Orders { get; set; }
        // علاقة بالحساب
       // public int UserAccountId { get; set; }
       // public UserAccount? UserAccount { get; set; }
    }

}
