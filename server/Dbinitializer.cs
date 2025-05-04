using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Model;
using Server.Data;

namespace server
{
    public class Dbinitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Seed categories if not present
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Bestseller" },
                    new Category { Name = "Award Winners" },
                    new Category { Name = "New Releases" },
                    new Category { Name = "New Arrival" },
                    new Category { Name = "Coming Soon" }
                );
                context.SaveChanges();
            }

            // Fetch categories
            var bestseller = context.Categories.FirstOrDefault(c => c.Name == "Bestseller");
            var awardWinner = context.Categories.FirstOrDefault(c => c.Name == "Award Winners");
            var newReleases = context.Categories.FirstOrDefault(c => c.Name == "New Releases");
            var newArrival = context.Categories.FirstOrDefault(c => c.Name == "New Arrival");
            var comingSoon = context.Categories.FirstOrDefault(c => c.Name == "Coming Soon");

            // Seed books if not present
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "C# in Depth",
                        Author = "Jon Skeet",
                        ISBN = "9781617294532",
                        Description = "Deep dive into C#",
                        Price = 39.99M,
                        InventoryCount = 10,
                        IsOnSale = false,
                        CategoryId = bestseller.Id
                    },
                    new Book
                    {
                        Title = "The Pragmatic Programmer",
                        Author = "Andy Hunt",
                        ISBN = "9780201616224",
                        Description = "Best practices for developers",
                        Price = 49.99M,
                        InventoryCount = 5,
                        IsOnSale = true,
                        CategoryId = awardWinner.Id
                    },
                    new Book
                    {
                        Title = "Clean Code",
                        Author = "Robert C. Martin",
                        ISBN = "9780132350884",
                        Description = "Agile software craftsmanship",
                        Price = 29.99M,
                        InventoryCount = 7,
                        IsOnSale = true,
                        CategoryId = newReleases.Id
                    },
                    new Book
                    {
                        Title = "Design Patterns",
                        Author = "Erich Gamma et al.",
                        ISBN = "9780201633610",
                        Description = "Reusable OOP design",
                        Price = 59.99M,
                        InventoryCount = 3,
                        IsOnSale = false,
                        CategoryId = newArrival.Id
                    },
                    new Book
                    {
                        Title = "Refactoring",
                        Author = "Martin Fowler",
                        ISBN = "9780134757599",
                        Description = "Improve code design",
                        Price = 39.99M,
                        InventoryCount = 8,
                        IsOnSale = false,
                        CategoryId = comingSoon.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}