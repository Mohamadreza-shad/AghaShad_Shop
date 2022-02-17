namespace AghaShad_Shop.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
