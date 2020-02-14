using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DHIS.Models
{
    [Table("Pharmacy", Schema = "dbo")]
    public class Pharmacy
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PharmacyID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Pharmancy Name")]
        public string PharmancyName { get; set; }


       
    }
}
