using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Models;

namespace PROJECT_NAME.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
         public DbSet<Person> Person { get; set;}
    }
}