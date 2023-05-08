using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models
{
    public class ProductComment
    {
        [Key]
        public int productCommentId { get; set; }

        [Column("productId")]
        public int productId { get; set; }

        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }

        [Column("Id")]
        public string Id { get; set; }

        [ForeignKey("Id")]
        public virtual User? User { get; set; }

        public string? title { get; set; }

        [StringLength(1000)]
        public string message { get; set; }

        public int rating { get; set; }
    }
}
