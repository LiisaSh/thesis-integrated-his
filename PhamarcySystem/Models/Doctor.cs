using System;
using System.Collections.Generic;

namespace PhamarcySystem.Models
{
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public string Userid { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Idnumber { get; set; }
        public int HosptalDoctorId { get; set; }

        public Hospital HosptalDoctor { get; set; }
    }
}
