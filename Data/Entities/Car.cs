using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
