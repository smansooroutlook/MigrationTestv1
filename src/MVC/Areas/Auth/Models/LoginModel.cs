using System.ComponentModel.DataAnnotations;

namespace Mvc.Areas.Auth.Models
{
    // login page ViewModel

    // ** Data Transfer Object (DTO) pattern

    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Min password length is 5 characters")]
        public string Password { get; set; }
    }
}