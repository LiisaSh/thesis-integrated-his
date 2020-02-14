using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models.IdentityModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    
        //public string ApplicationRoleId { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
       
        public string Accountstatus { get; set; }
    
        //public List<string> UserRoles { get; set; }

    }
}
