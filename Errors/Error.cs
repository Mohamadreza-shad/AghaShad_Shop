namespace AghaShad_Shop.Errors
{
    public class Error
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }
        public object Code { get; set; }


        public static readonly Error CustomerNotFound = new()
        {
            Id = 1,
            Title = "Cuctomer not found",
            TitleFa = "مشتری پیدا نشد",
        };

        public static readonly Error ProductNotFound = new()
        {
            Id = 2,
            Title = "Product not found",
            TitleFa = "محصول پیدا نشد",
        };

        public static readonly Error ShipperNotFound = new()
        {
            Id = 2,
            Title = "Shipper not found",
            TitleFa = "باربر پیدا نشد",
        };


        public static readonly Error NoShipperExists = new()
        {
            Id = 4,
            Title = "No Shipper Exists",
            TitleFa = "هیچ باربری پیدا نشد",
        };
    }
}
