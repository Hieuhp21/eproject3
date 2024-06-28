namespace catere_be.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }

}
