using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class IngredientPurchase
    {
        
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public int IngredientID { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Quantity { get; set; }

        // علاقات
        public Supplier ?Supplier { get; set; }
        public Ingredient ?Ingredient { get; set; }
    }

}
