using System;
using System.Collections.Generic;

namespace PhamarcySystem.Models
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public int PrescriptionPatientId { get; set; }
        public string PrescriptionNotes { get; set; }
        public string Diagonosis { get; set; }
        public string DiagonosisBy { get; set; }
        public bool PrescriptionCollected { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Idnumber { get; set; }

        public Patient PrescriptionPatient { get; set; }
    }
}
