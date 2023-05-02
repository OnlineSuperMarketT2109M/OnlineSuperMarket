namespace OnlineSuperMarket.Models.ViewModel
{
    public class CartItem
    {
        public int quantity { set; get; }
        public Product product { set; get; }
        public ProductImage productImage { set; get; }
        public double TotalMoney => quantity * product.unitCost;
    }
}
