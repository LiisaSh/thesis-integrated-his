using System;
using System.Collections.Generic;

namespace DHISWEBAPI.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<Doctor> Doctor { get; set; }
    }
}
