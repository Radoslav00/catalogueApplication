using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int? PositionID { get; set; }
        public virtual Position Positions { get; set; }
    }
}
