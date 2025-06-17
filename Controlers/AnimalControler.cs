using Animals_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals_project.Controlers
{
    internal class AnimalControler
    {
        private AnimalContext _AnimalContext = new AnimalContext();
        public Animal Get(int id)
        {
            Animal findedAnimal = _AnimalContext.Animals.Find(id);
            if (findedAnimal != null)
            {
                _AnimalContext.Entry(findedAnimal).Reference(x => x.Breed).Load();
            }
            return findedAnimal;
        }

        public List<Animal> GetAll()
        {
            return _AnimalContext.Animals.Include("Breed").ToList();
        }


        public void Create(Animal animal)
        {
            _AnimalContext.Animals.Add(animal);
            _AnimalContext.SaveChanges();
        }

        public void Update(int id, Animal animal)
        {
            Animal findedAnimal = _AnimalContext.Animals.Find(id);
            if (findedAnimal == null) 
            {
                return;
            }
            findedAnimal.age = animal.age;
            findedAnimal.name = animal.name;
            findedAnimal.BreedId = animal.BreedId;
            _AnimalContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Animal findedAnimal = _AnimalContext.Animals.Find(id);
            _AnimalContext.Animals.Remove(findedAnimal);
            _AnimalContext.SaveChanges();
        }
    }
}
    

