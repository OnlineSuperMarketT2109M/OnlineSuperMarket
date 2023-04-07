using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        [Column("userId")]
        public int userId { get; set; }

        [ForeignKey("Id")]
        public virtual User? User { get; set; }
        [Column("productId")]
        public int productId { get; set; }

        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }

        public int amount { get; set; }

        public DateTime purchaseDate { get; set; }
    }
}
