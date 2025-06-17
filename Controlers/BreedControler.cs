using Animals_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals_project.Controlers
{
    internal class BreedControler
    {
        private AnimalContext _AnimalContext = new AnimalContext();
        public List<Breed> GetAllBreeds()
        {
            return _AnimalContext.Breeds.ToList();
        }

        
        public string GetBreedById(int id)
        {
            return _AnimalContext.Breeds.Find(id).name;
        }
    }
}

    

