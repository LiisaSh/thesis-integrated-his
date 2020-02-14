using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    [Table("Medicine", Schema = "dbo")]
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Medicine Code")]
        public string MedicineCode { get; set; }

        [Required]
        [Display(Name = "Pharmacy")]
        [ForeignKey("PharmacyInfo")]
        public int PharmacyMedicID { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }

        [Required]
        [Column(TypeName = "varchar(2000)")]
        [Display(Name = "Diseases Cured")]
        public string DiseaseCured { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

       


        [Display(Name = "Pharmacy")]
        public virtual Pharmacy PharmacyInfo { get; set; }


    }
}
