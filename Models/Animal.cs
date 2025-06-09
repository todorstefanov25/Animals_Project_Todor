using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals_project.Models
{
    public class Animal
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int age { get; set; }
        public int BreedId{ get; set; }
        public Breed Breed {  get; set; }
    }
}
