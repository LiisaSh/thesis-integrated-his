using System;
using System.Collections.Generic;

namespace DHISWEBAPI.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Medicine = new HashSet<Medicine>();
        }

        public int PharmacyId { get; set; }
        public string PharmancyName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<Medicine> Medicine { get; set; }
    }
}
