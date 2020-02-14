using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models.IdentityModels
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You must enter your Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "You must enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
