using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models
{
    public class Brand
    {
        [Key]
        public int brandId { get; set; }

        public string brandName { get; set; }
    }
}
