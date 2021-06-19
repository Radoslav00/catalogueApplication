using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Zone
    {
        public int ZoneID { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Zone name can't be that long!")]
        public string ZoneName { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

    }
}
