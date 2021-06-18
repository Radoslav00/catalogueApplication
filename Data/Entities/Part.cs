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
        
        public string PartName { get; set; }
        
        public double Price { get; set; }
        
        public string CatalogueNumber { get; set; }

        public int ZoneID { get; set; }
        
        public virtual Zone Zone { get; set; }

        public int CarID { get; set; }
        
        public virtual Car Car { get; set; }
    }
}
