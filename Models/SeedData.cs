using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Data;

namespace RazorPagesBook.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesBookContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesBookContext>>()))
        {
            if (context == null || context.Book == null)
            {   
                throw new ArgumentNullException("Null RazorPagesBookContext");
            }

            // Look for any books.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    ReleaseDate = DateTime.Parse("1960-07-11"),
                    Genre = "Fiction",
                    Price = 7.99M,
                    Rating = "R"
                },

                new Book
                {
                    Title = "1984",
                    ReleaseDate = DateTime.Parse("1949-06-08"),
                    Genre = "Dystopian",
                    Price = 8.99M,
                    Rating = "R"
                },

                new Book
                {
                    Title = "The Great Gatsby",
                    ReleaseDate = DateTime.Parse("1925-04-10"),
                    Genre = "Tragedy",
                    Price = 10.99M,
                    Rating = "R"
                },

                new Book
                {
                    Title = "The Catcher in the Rye",
                    ReleaseDate = DateTime.Parse("1951-07-16"),
                    Genre = "Fiction",
                    Price = 6.99M,
                    Rating = "R"
                }
            );
            context.SaveChanges();
        }
    }
}