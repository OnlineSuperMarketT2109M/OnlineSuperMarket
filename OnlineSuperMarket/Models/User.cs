using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Column("firstName"), StringLength(255)]
        public string FirstName { get; set; }
        [PersonalData]
        [Column("middleName"), StringLength(255)]
        public string? MiddleName { get; set; }
        [PersonalData]
        [Column("lastName"), StringLength(255)]
        public string LastName { get; set; }
        [PersonalData]
        [Column("address"), StringLength(255)]
        public string Address { get; set; }
        [PersonalData]
        public string? Avatar { get; set; }

        [NotMapped]
        [DisplayName("Upload Avatar")]
        public IFormFile ImageFile { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
