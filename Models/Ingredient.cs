namespace SweetShop.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }

        
        // علاقات
        public ICollection<ProductRecipe> ?ProductRecipes { get; set; }
        public ICollection<IngredientPurchase> ?IngredientPurchases { get; set; }
    }

}
