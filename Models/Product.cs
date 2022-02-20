using AghaShad_Shop.Enums;

namespace AghaShad_Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
