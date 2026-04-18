namespace SweetShop.Models
{
    // نموذج يمثل العنصر في السلة (CartItem)
    public class CartItem
    {
        public int ProductId { get; set; }  // معرف المنتج
        public string? ProductName { get; set; }  // اسم المنتج
        public decimal Price { get; set; }  // سعر المنتج
        public int Quantity { get; set; }  // الكمية المطلوبة
    }

    // نموذج السلة الذي يحتوي على العناصر (CartViewModel)
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();  // عناصر السلة
        public decimal TotalPrice { get; set; }  // المجموع الكلي
    }
}
