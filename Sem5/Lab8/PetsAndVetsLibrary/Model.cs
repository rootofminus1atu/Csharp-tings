using System.Text.Json.Serialization;
using System.Text.Json;

namespace PetsAndVetsLibrary
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public ICollection<VetVisit> VetVisits { get; set; }
    }

    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }

    public class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VetVisit> VetVisits { get; set; }
    }

    public class VetVisit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int VetId { get; set; }
        public Vet Vet { get; set; }
        
    }

    public static class DebugExtensions
    {
        public static string ToDebugString(this object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
