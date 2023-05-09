using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
