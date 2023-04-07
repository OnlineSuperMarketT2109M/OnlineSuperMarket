using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class Bill
    {
        [Key]
        public int billId { get; set; }

        public string creditCardNumber { get; set; }

        public double billAmount { get; set; }
        [Column("orderId")]
        public int orderId { get; set; }

        [ForeignKey("orderId")]
        public virtual Order? Order { get; set; }
    }
}
