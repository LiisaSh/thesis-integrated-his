using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models.IdentityModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        [Display(Name = "Subscription Date")]
        public DateTime SubscriptionDate { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; }
        public string RoleName { get; set; }
    }
}
