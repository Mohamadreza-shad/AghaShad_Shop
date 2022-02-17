namespace AghaShad_Shop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        private decimal _total;
        public decimal TotalPrice 
        { get{   return _total = Quantity * UnitPrice;} 
          set{   _total = value;} 
        }

        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
