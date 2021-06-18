using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Position
    {
        public int PositionID { get; set; }
        public string PositionTitle { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
