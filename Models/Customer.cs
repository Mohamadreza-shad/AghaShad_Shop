namespace AghaShad_Shop.Models
{
    public class Customer
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Phone { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
