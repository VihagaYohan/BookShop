using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        
        // tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}