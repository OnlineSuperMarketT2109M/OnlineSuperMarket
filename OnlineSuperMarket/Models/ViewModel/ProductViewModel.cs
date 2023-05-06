namespace OnlineSuperMarket.Models.ViewModel
{
    public class ProductViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string? productImage { get; set; }
        public double unitCost { get; set; }

        public string brandName { get; set; }

        public string categoryName { get; set; }

        public string? status { get; set; }

        public string? color { get; set; }
        public string? size { get; set; }

        public int? quantity { get; set; }

        public int? totalAmount { get; set; }
    }
}
