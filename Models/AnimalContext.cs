using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals_project.Models
{
    public class AnimalContext:DbContext
    {
        public AnimalContext() : base("AnimalContext")
        {
        }
        public DbSet<Animal>Animals { get; set; }
        public DbSet<Breed>Breeds { get; set; }
    }
}
