using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    [Table("Hospital", Schema = "dbo")]
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HospitalID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }




        
    }
}
