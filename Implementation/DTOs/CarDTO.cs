using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class CarDTO
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
    }
}
