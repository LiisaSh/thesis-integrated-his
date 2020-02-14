using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    [Table("Doctor", Schema = "dbo")]
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorID { get; set; }

        public  string Userid { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Doctor Full name")]
        public string FullName { get; set; }


        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Doctor Email")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "Hospital")]
        [ForeignKey("HospitalInfo")]
        public int HosptalDoctorID { get; set; }

        [Display(Name = "Hospital")]
        public virtual Hospital HospitalInfo { get; set; }

    }
}
