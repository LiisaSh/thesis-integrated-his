using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    [Table("Prescription", Schema = "dbo")]
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescriptionID { get; set; }


        [Required]
        [Display(Name = "Patient")]
        [ForeignKey("PatientInfo")]
        public int PrescriptionPatientID { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Prescription Notes")]
        public string PrescriptionNotes { get; set; }


        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Diagonosis")]
        public string Diagonosis { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Diagonosis By")]
        public string DiagonosisBy { get; set; }

        [Required]
        [Display(Name = "Prescriptions Collected")]
        public bool PrescriptionCollected { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "ID Number")]
        public string Idnumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Created By")]
        public string Created_by { get; set; }


        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Modified By")]
        public string Modified_by { get; set; }


        [Display(Name = "Created on")]
        public DateTime Created_on { get; set; }


        [Display(Name = "Modified on")]
        public DateTime Modified_on { get; set; }

        [Display(Name = "Patient")]
        public virtual Patient PatientInfo { get; set; }

    }
}
