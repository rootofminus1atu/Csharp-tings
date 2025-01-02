// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PetsAndVetsLibrary;

Console.WriteLine("Hello, World!");

static void SeedDb()
{
    using (var context = new PetsAndVetsContext())
    {
        context.Database.EnsureCreated();

        if (context.Owners.Any())
        {
            return;
        }

        context.Owners.AddRange(SeedData.GetOwners());
        context.Pets.AddRange(SeedData.GetPets());
        context.Vets.AddRange(SeedData.GetVets());
        context.VetVisits.AddRange(SeedData.GetVetVisits());

        context.SaveChanges();
        Console.WriteLine("all good");
    }
}

SeedDb();


using (var context = new PetsAndVetsContext())
{
    var l1 = context.Vets
        .ToList();

    Console.WriteLine($"l1. all vets\n{l1.ToDebugString()}\n");
}

using (var context = new PetsAndVetsContext())
{
    var l2 = context.Owners
        .Include(o => o.Pets)
        .ToList();

    Console.WriteLine($"l2. all owners with their pets: \n{l2.ToDebugString()}\n");
}

using (var context = new PetsAndVetsContext())
{
    var l3 = context.VetVisits
        .Include(vv => vv.Pet)
        .Include(vv => vv.Vet)
        .Select(vv => new
        {
            VisitId = vv.Id,
            VisitDate = vv.VisitDate,
            PetName = vv.Pet.Name,
            PetSpecies = vv.Pet.Species,
            VetName = vv.Vet.Name
        })
        .ToList();

    Console.WriteLine($"l3. all vet visits with their pets and vets:\n{l3.ToDebugString()}\n");
}

using (var context = new PetsAndVetsContext())
{
    var l4 = context.Pets
        .Include(p => p.VetVisits)
        .Select(p => new
        {
            PetName = p.Name,
            PetSpecies = p.Species,
            VisitCount = p.VetVisits.Count()
        })
        .ToList();

    Console.WriteLine($"l4. each pet with the number of vet visits:\n{l4.ToDebugString()}\n");
}

using (var context = new PetsAndVetsContext())
{
    var l5 = context.Vets
        .Include(v => v.VetVisits)
        .ThenInclude(vv => vv.Pet)
        .Select(v => new
        {
            VetName = v.Name,
            TreatedPets = v.VetVisits.Select(vv => vv.Pet.Name).ToList()
        })
        .ToList();

    Console.WriteLine($"l5. each vet with the pets they will treat (or treated):\n{l5.ToDebugString()}\n");
}
