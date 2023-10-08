using Microsoft.EntityFrameworkCore;
using ReviewWebsite.Domain.Menu;

namespace ReviewWebsite.Infrastructure.Persistence
{
    public class ReviewWebsiteContext : DbContext
    {
        public ReviewWebsiteContext(DbContextOptions<ReviewWebsiteContext> options) :
               base(options)
        {

        }

        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ReviewWebsiteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
