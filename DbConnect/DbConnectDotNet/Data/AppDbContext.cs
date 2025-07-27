using Microsoft.EntityFrameworkCore;

namespace FromScratch.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Models.Product> products { get; set; } = default!;
    }
}
