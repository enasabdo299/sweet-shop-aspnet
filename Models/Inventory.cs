namespace SweetShop.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int? StockQuantity { get; set; }
        public DateTime? LastUpdated { get; set; }

        // علاقات
        public Product ?Product { get; set; }
    }

}
