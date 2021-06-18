using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Zone
    {
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

    }
}
