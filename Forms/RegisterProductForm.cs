using AghaShad_Shop.Enums;

namespace AghaShad_Shop.Forms
{
    public class RegisterProductForm
    {
        public string Name { get; set; }
        public ProductSize Size { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
