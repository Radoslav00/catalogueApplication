using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProjectDbContext2 : DbContext
    {
        public DbSet<Part> Parts { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Zone> Zones { get; set; }
    }
}
