using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models.IdentityModels
{
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
}
