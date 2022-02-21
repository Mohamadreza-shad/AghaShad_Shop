using AghaShad_Shop.DataContext;
using AghaShad_Shop.OutPut;

namespace AghaShad_Shop.Views
{
    public class CustomerAddressView
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }
}
