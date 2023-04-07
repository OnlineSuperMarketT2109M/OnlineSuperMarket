using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSuperMarket.Models
{
    public class BlogComment
    {
        [Key]
        public int blogCommentId { get; set; }
        [Column("blogId")]
        public int blogId { get; set; }

        [ForeignKey("blogId")]
        public virtual Blog? Blog { get; set; }
        [Column("userId")]
        public int userId { get; set; }

        [ForeignKey("Id")]
        public virtual User? User { get; set; }

        [StringLength(1000)]
        public string message { get; set; }
    }
}
