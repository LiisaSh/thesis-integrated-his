using System;
using System.Collections.Generic;

namespace DHISWEBAPI.Models
{
    public partial class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineCode { get; set; }
        public int PharmacyMedicId { get; set; }
        public string MedicineName { get; set; }
        public string DiseaseCured { get; set; }
        public double Quantity { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public Pharmacy PharmacyMedic { get; set; }
    }
}
