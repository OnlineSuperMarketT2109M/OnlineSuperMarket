using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models
{
    public class ProductSize
    {
        [Key]
        public int productSizeId { get; set; }

        [Column("productId")]
        public int productId { get; set; }

        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }

        public string size { get; set; }
    }
}
