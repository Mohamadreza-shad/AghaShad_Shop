namespace AghaShad_Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
