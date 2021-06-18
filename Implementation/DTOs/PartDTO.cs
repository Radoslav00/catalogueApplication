using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class PartDTO
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public double Price { get; set; }
        public string CatalogueNumber { get; set; }

        public int ZoneID { get; set; }
        public virtual ZoneDTO Zone { get; set; }

        public int CarID { get; set; }
        public virtual CarDTO Car { get; set; }
    }
}
