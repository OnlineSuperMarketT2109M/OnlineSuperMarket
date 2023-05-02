using System.ComponentModel.DataAnnotations;

namespace OnlineSuperMarket.Models.ViewModel
{
    public class CheckoutViewModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your fullname")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your delivery address")]
        public string Address { get; set; }
        
    }
}
