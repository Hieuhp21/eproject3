namespace catere_be.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public float Price { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual Service Service { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public virtual ICollection<CustomerOrderMenu> CustomerOrderMenus { get; set; }
    }

}
