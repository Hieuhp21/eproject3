namespace catere_be.Models
{
    public class Menu
    {
        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<CustomerOrderMenu> CustomerOrderMenus { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }

}
