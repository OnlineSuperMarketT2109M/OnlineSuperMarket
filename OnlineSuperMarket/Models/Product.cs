using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace OnlineSuperMarket.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [StringLength(255)]
        public string productName { get; set; }

        public double unitCost { get; set; }

        public int quantity { get; set; }

        public int totalAmount { get; set; }    

        public string? status { get; set; }
        public string? color { get; set; }
        public string? size { get; set; }
        [StringLength(5000)]
        public string? description { get; set; }

        public int brandId { get; set; }

        public int categoryId { get; set; }

        [ForeignKey("categoryId")]
        public virtual Category? Category { get; set; }

        [ForeignKey("brandId")]
        public virtual Brand? Brand { get; set; }

        public ICollection<ProductImage> productImages { get; set; }

        public ICollection<OrderDetails> orderDetails { get; set; }
        
    }
}
