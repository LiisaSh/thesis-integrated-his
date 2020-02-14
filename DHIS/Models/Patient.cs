using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    [Table("Patient", Schema = "dbo")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }

       
        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Patient Full name")]
        public string FullName { get; set; }

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
        [Column(TypeName = "Varchar(100)")]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        [Display(Name = "Cellphone Number")]
        public string CellphoneNumber { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        [Display(Name = "Residential Address")]
        public string ResidentialAddress { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        [Display(Name = "Next of Kin")]
        public string NextOfKin { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        [Display(Name = "Next of Kin Cellphone")]
        public string NextOfKinCell { get; set; }

        [Column(TypeName = "Text")]
        [Display(Name = "Patient profile Image")]
        [NotMappedAttribute]
        public IFormFile ProfileImage { get; set; }

        [Column(TypeName = "Text")]
        [Display(Name = "Profile Imabe")]
        public string ImagePath { get; set; }



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


    }
}
