namespace SweetShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? ImagePath { get; set; } // Add this line

        // علاقات
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public ICollection<ProductRecipe>? ProductRecipes { get; set; }
    }

}
