namespace catere_be.Models
{
    public class CustomerOrderMenu
    {
        public int OrderMenuId { get; set; }
        public int MenuItemId { get; set; }
        public int RoomId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public virtual Menu MenuItem { get; set; }
        public virtual Room Room { get; set; }
        public virtual CustomerOrder Order { get; set; }
    }

}
