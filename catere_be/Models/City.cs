namespace catere_be.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }

}
