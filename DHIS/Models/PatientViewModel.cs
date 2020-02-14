using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    public class PatientViewModel
    {
        public Patient GetPatientDetails { get; set; }

        public List<Prescription> GetPrescriptions { get; set; }
    }
}
