using Lab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Lab2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MvcContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcContext>>()
            );

            if (context.Client.Any() && context.Book.Any())
            {
                return;
            }

            // Look for any Clients.
            if (!context.Client.Any())
            {
                context.Client.AddRange(
                 new Client
                 {
                     FirstName = "Jan",
                     LastName = "Kowalski",
                     Email = "jk@example.com",
                     BirthDate = DateTime.Parse("20-02-1992")
                 },
                 new Client
                 {
                     FirstName = "Karolina",
                     LastName = "Nowak",
                     Email = "kn@example.com",
                     BirthDate = DateTime.Parse("06-01-1987")
                 },
                 new Client
                 {
                     FirstName = "Karol",
                     LastName = "Karolowski",
                     Email = "kk@example.com",
                     BirthDate = DateTime.Parse("11-11-1971")
                 }
             );
            }

            // Look for any Books
            if(!context.Book.Any())
            {
                context.Book.AddRange(
                    new Book
                    {
                        Title = "Był sobie Jan",
                        ReleaseDate = DateTime.Parse("01-03-1965"),
                        Rating = 3,
                        Author = "Jan Autorski"
                    },
                    new Book
                    {
                        Title = "Nowe życie",
                        ReleaseDate = DateTime.Parse("11-04-1983"),
                        Rating = 9,
                        Author = "Joanna Życiowska"
                    }
                );
            }
            
            context.SaveChanges();
        }
    }
}
