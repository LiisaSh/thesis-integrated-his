using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhamarcySystem.Models
{
    public class PreScribeClass
    {
        public int PrescriptionId { get; set; }
        public int PrescriptionPatientId { get; set; }
        public string PrescriptionNotes { get; set; }
        public string Diagonosis { get; set; }
        public string DiagonosisBy { get; set; }
        public bool PrescriptionCollected { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Idnumber { get; set; }
    }
}
