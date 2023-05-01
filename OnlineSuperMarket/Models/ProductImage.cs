using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class ProductImage
    {
        [Key]
        public int productImageId { get; set; }
        [Column("productId")]
        public int productId { get; set; }

        [ForeignKey("productId")]
        public Product? Product { get; set; }
        public string productImage { get; set; }

        [NotMapped, DisplayName("Upload Product Image")]
        public IFormFile ImageFile { get; set; }
    }
}
