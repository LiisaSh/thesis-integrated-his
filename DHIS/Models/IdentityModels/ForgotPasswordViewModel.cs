using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models.IdentityModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You must enter your Email!")]
        [EmailAddress(ErrorMessage = "You must enter a valid email address.")]
        public string Email { get; set; }
    }
}
