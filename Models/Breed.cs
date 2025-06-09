using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals_project.Models
{
    public class Breed
    {
        public int id {  get; set; }
        public string name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
