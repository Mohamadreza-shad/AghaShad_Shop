namespace AghaShad_Shop.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
    }
}
