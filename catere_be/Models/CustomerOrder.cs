using System.ComponentModel.DataAnnotations;

namespace catere_be.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float VAT { get; set; }
        public string Status { get; set; }
        public int PeopleCount { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public float TotalPrice { get; set; }
        public bool IsActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<CustomerOrderMenu> CustomerOrderMenus { get; set; }
        public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; }
    }

}
