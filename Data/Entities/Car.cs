using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Car make must be maximum 25 letters")]
        public string Make { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Car manufacturer must be maximum 25 letters")]
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Car fuel type must be maximum 10 letters")]
        public string Fuel { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
