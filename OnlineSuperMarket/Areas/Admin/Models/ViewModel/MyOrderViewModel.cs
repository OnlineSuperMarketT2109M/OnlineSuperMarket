using OnlineSuperMarket.Models;
namespace OnlineSuperMarket.Areas.Admin.Models.ViewModel
{
    public class MyOrderViewModel
    {
        public List<Order>? orders { get; set; }
        public List<Order>? orderPending { get; set; }
        public List<Order>? orderProcessing { get; set; }
        public List<Order>? orderCompleted { get; set; }
        public List<Order>? orderCanceled { get; set; }
    }
}
