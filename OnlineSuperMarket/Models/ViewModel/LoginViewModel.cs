using Microsoft.Build.Framework;

namespace OnlineSuperMarket.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
