using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Part
    {
        public int PartID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage ="Name is too long!")]
        public string PartName { get; set; }
        [Required]
        [Range(1, 9999.99, ErrorMessage ="price must be between 1 and 9999.99" )]
        public double Price { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="Catalogue number must be 10 digits")]
        [MinLength(10)]
        public string CatalogueNumber { get; set; }
        [Required]
        public int ZoneID { get; set; }
        
        public virtual Zone Zone { get; set; }
        [Required]
        public int CarID { get; set; }
        
        public virtual Car Car { get; set; }
    }
}
