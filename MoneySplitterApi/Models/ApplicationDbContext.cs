using Microsoft.EntityFrameworkCore;

namespace MoneySplitterApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Debts> Debts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MoneySplitterDb;Username=postgres;Password=wasdwasd543210");
        }
    }
}
