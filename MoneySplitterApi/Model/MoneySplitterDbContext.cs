using Microsoft.EntityFrameworkCore;

namespace MoneySplitterApi.Model
{
    public class MoneySplitterDbContext : DbContext
    {
        public MoneySplitterDbContext(DbContextOptions<MoneySplitterDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(b => b.guid);
            base.OnModelCreating(builder);
        }

    }
}
