namespace SweetShop.Models
{
    public class ProductRecipe
    {
        public int RecipeID { get; set; }
        public int ProductID { get; set; }
        public int IngredientID { get; set; }
        public int? Quantity { get; set; }

        // علاقات
        public Product? Product { get; set; }
        public Ingredient? Ingredient { get; set; }
    }

}
