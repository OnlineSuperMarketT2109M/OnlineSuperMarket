using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineSuperMarket.Areas.Admin.Models.ViewModel
{
    public class UserUpdateVM
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string? MiddleName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [StringLength(255)]
        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [DisplayName("Locked Out")]
        public bool IsLockedOut { get; set; }
        [NotMapped]
        [DisplayName("Upload Avatar")]
        public IFormFile? ImageFile { get; set; }
    }
}
