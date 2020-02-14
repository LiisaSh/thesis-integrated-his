using System;
using System.Collections.Generic;

namespace PhamarcySystem.Models
{
    public partial class Hospital
    {
        public Hospital()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
       

        public ICollection<Doctor> Doctor { get; set; }
    }
}
