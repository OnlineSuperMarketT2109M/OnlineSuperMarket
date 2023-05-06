using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        [Column("userId")]
        public string Id { get; set; }

        [ForeignKey("Id")]
        public virtual User? User { get; set; }
        public double total { get; set; }

        public string Address { get; set; }
        public string orderStatus { get; set; }

        public DateTime purchaseDate { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
