using System;
using System.Collections.Generic;

namespace PhamarcySystem.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Medicine = new HashSet<Medicine>();
        }

        public int PharmacyId { get; set; }
        public string PharmancyName { get; set; }
     

        public ICollection<Medicine> Medicine { get; set; }
    }
}
