using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class ProductDetail
    {
        [Key]
        public int productDetailId { get; set; }

        [Column("productId")]
        public int productId { get; set; }

        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }

        public string color { get; set; }

        public string size { get; set; }

        [StringLength(5000)]
        public string description { get; set; }
    }
}
