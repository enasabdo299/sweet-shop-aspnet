namespace SweetShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email  { get; set; }

        // علاقات
        public ICollection<Order> ?Orders { get; set; }
        // علاقة بالحساب
        //public int UserAccountId { get; set; }
       // public UserAccount? UserAccount { get; set; }
    }

}
