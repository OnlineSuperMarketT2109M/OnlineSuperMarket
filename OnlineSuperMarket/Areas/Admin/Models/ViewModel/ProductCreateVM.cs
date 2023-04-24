using OnlineSuperMarket.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Areas.Admin.Models.ViewModel
{
    public class ProductCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double unitCost { get; set; }
        
        public int quantity { get; set; }

        public int totalAmount { get; set; }

        public string? status { get; set; }

        [StringLength(5000)]
        public string? description { get; set; }
        
        public int brandId { get; set; }

        public int categoryId { get; set; }

        public string color { get; set; }

        public string size { get; set; }

        [DisplayName("Product Image")]
        public IFormFile formFile { get; set; }
    }
}
