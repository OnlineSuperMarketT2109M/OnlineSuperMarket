using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class Blog
    {
        [Key]
        public int blogId { get; set; }

        public string title { get; set; }

        [StringLength(5000)]
        public string content { get; set; }

        public string thumbnail { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
