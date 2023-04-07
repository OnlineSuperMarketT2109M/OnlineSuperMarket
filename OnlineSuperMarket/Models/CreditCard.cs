using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class CreditCard
    {
        [Key]
        public int creditCardId { get; set; }

        [StringLength(30)]
        public string creditCardNumber { get; set; }
        public DateTime creditCardExpiry { get; set; }

        [Column("userId")]
        public int userId { get; set; }

        [ForeignKey("Id")]
        public virtual User? User { get; set; }
    }
}
