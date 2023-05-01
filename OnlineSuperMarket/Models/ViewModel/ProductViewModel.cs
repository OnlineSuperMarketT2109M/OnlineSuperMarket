namespace OnlineSuperMarket.Models.ViewModel
{
    public class ProductViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public double unitCost { get; set; }

        public string brandName { get; set; }

        public string categoryName { get; set; }
    }
}
