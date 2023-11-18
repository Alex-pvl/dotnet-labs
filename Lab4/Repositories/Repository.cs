using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Repositories
{
    public class Repository : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public Repository(DbContextOptions options) : base(options) { }
    }
}
