namespace AghaShad_Shop.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
