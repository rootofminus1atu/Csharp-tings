using Microsoft.EntityFrameworkCore;
using RADLab3Solution.Data;

namespace RADLab3Solution.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RADLab3SolutionContextSQLite(
            serviceProvider.GetRequiredService<
                DbContextOptions<RADLab3SolutionContextSQLite>>()))
        {
            if (context == null || context.Book == null)
            {
                throw new ArgumentNullException("Null Context");
            }

            // Look for any movies.
            if (!context.Author.Any())
            {
                Publisher gau = new Publisher
                {
                    Name = "George Allen & Unwin"
                };


                Publisher gb = new Publisher
                {
                    Name = "Geoffrey Bles"
                };

                context.Publisher.Add(gau);
                context.Publisher.Add(gb);

                Author jrr = new Author
                {
                    Name = "JRR Tolkien"
                };

                Author csl = new Author
                {
                    Name = "C. S. Lewis"
                };

                context.Author.Add(jrr);
                context.Author.Add(csl);

                context.Book.AddRange(
                    new Book
                    {
                        Title = "The Hobbit",
                        CoverPage = "TheHobbit.jpg",
                        Author = jrr,
                        Publisher = gau,
                        PublicationDate = DateOnly.Parse("21/09/1937"),
                        Summary = "Bilbo Baggins, a hobbit, is persuaded into accompanying the wizard Gandalf and a group of dwarves on a journey to reclaim the dwarfish city of Erebor and all its riches from the dragon Smaug."
                    },

                    new Book
                    {
                        Title = "The Lion, the Witch and the Wardrobe",
                        Author = csl,
                        Publisher = gb,
                        PublicationDate = DateOnly.Parse("16/10/1950"),
                        CoverPage = "TheLionWitchWardrobe.jpg",
                        Summary = "The Lion, the Witch and the Wardrobe is a portal fantasy novel for children by C. S. Lewis, published by Geoffrey Bles in 1950. It is the first published and best known of seven novels in The Chronicles of Narnia. Among all the author's books, it is also the most widely held in libraries. Wikipedia"
                    }

                );
            }
            context.SaveChanges();
        }
    }
}