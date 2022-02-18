using AghaShad_Shop.Enums;

namespace AghaShad_Shop.Forms
{
    public class RegisterOrderForm
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductSize Size { get; set; }
        public int ShippingId { get; set; }
    }
}
