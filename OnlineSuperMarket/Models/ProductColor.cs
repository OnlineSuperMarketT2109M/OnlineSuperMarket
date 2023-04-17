using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class ProductColor
    {
        [Key]
        public int productColorId { get; set; }

        [Column("productId")]
        public int productId { get; set; }

        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }

        public string color { get; set; }
    }
}
