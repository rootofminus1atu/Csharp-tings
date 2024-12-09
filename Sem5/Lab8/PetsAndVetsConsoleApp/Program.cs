// See https://aka.ms/new-console-template for more information
using PetsAndVetsLibrary;

Console.WriteLine("Hello, World!");

static void SeedDb()
{
    using (var context = new PetsAndVetsContext())
    {
        context.Database.EnsureCreated();

        context.Owners.AddRange(SeedData.GetOwners());
        context.Pets.AddRange(SeedData.GetPets());
        context.Vets.AddRange(SeedData.GetVets());
        context.VetVisits.AddRange(SeedData.GetVetVisits());

        context.SaveChanges();
        Console.WriteLine("all good");
    }
}

// SeedDb();
using (var context = new PetsAndVetsContext())
{
    context.Vets.ToList().ForEach(v => Console.WriteLine(v.Name));
}
