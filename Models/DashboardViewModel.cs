namespace SweetShop.Models
{
    // لا تضف هذا النموذج إلى DbContext
    public class DashboardViewModel
    {
        public int TotalCustomers { get; set; }
        public int TotalOrders { get; set; }
        public int TotalProducts { get; set; }
        public int Employee { get; set; }
        public int Invoice { get; set; }
        public int Inventory { get; set; }
        public int OrderDetail { get; set; }
        public int ProductRecipe { get; set; }
        public int Supplier { get; set; }
        public int Ingredients { get; set; }
        public int IngredientPurchases { get; set; }

    }

}
