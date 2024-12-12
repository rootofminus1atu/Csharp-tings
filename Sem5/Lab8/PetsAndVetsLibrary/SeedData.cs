using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsAndVetsLibrary
{
    public static class SeedData
    {
        public static List<Owner> GetOwners()
        {
            var owners = new List<Owner>
            {
                new Owner { Id = 1, Name = "John Doe" },
                new Owner { Id = 2, Name = "Jane Doe" },
                new Owner { Id = 3, Name = "Michael Jackson" }
            };

            return owners;
        }

        public static List<Pet> GetPets()
        {
            var pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Fluffles", Species = "Dog", OwnerId = 1 },
                new Pet { Id = 2, Name = "Bingus", Species = "Cat", OwnerId = 1 },
                new Pet { Id = 3, Name = "Princess", Species = "Dog", OwnerId = 2 },
                new Pet { Id = 4, Name = "Marty McFly", Species = "Parrot", OwnerId = 2 },
                new Pet { Id = 5, Name = "Big Floppa", Species = "Cat", OwnerId = 3 }
            };

            return pets;
        }

        public static List<Vet> GetVets()
        {
            var vets = new List<Vet>
            {
                new Vet { Id = 1, Name = "Dr. V1" },
                new Vet { Id = 2, Name = "Dr. V2" },
                new Vet { Id = 3, Name = "Dr. V3" }
            };

            return vets;
        }

        public static List<VetVisit> GetVetVisits()
        {
            var vetVisits = new List<VetVisit>
            {
                new VetVisit { Id = 1, VisitDate = DateTime.Now.AddDays(-7), PetId = 1, VetId = 1 },
                new VetVisit { Id = 2, VisitDate = DateTime.Now.AddDays(-14), PetId = 1, VetId = 2 },
                new VetVisit { Id = 3, VisitDate = DateTime.Now.AddDays(-21), PetId = 3, VetId = 3 },
                new VetVisit { Id = 4, VisitDate = DateTime.Now.AddDays(-28), PetId = 4, VetId = 1 },
                new VetVisit { Id = 5, VisitDate = DateTime.Now.AddDays(-35), PetId = 5, VetId = 2 }
            };

            return vetVisits;
        }
    }
}
