using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }

        [StringLength(255)]
        public string categoryName { get; set; }
    }
}
