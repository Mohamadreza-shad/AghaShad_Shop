using AghaShad_Shop.Enums;

namespace AghaShad_Shop.DTOs
{
    public class RegisterOrderDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductSize Size { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
