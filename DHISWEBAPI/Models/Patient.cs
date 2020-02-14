using System;
using System.Collections.Generic;

namespace DHISWEBAPI.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Idnumber { get; set; }
        public string Dob { get; set; }
        public string CellphoneNumber { get; set; }
        public string PostalAddress { get; set; }
        public string ResidentialAddress { get; set; }
        public string NextOfKin { get; set; }
        public string NextOfKinCell { get; set; }
        public string ImagePath { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ICollection<Prescription> Prescription { get; set; }
    }
}
