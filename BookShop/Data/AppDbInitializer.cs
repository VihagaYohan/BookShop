using System;
using System.Linq;
using BookShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Data
{
    public static class AppDbInitializer
    {
        // seed database with default values
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScrop = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScrop.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st book title",
                        Description = "1st book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First author",
                        CoverUrl = "Http...//..",
                        DateAdded = DateTime.Now
                    },
                       new Book(){
                           Title = "2nd book title",
                           Description = "2nd book description",
                           IsRead = false,
                           Genre = "History",
                           Author = "Second author",
                           CoverUrl = "Http...//..",
                           DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }

                
            }
        }
    }
}