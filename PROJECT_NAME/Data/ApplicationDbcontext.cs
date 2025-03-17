using Microsoft.EntityFrameworkCore;
using PROJECT_NAME.Models;
using PROJECT_NAME.Models.Models;

namespace PROJECT_NAME.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
         public DbSet<Person> Person { get; set;}
         public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set;}
        public DbSet<PROJECT_NAME.Models.Models.Daily> Daily { get; set; } = default!;
        public DbSet<PROJECT_NAME.Models.Employee> Employee { get; set; } = default!;
    }
}