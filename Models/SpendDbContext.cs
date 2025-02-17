using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SpendDbContext : DbContext

    {
        public SpendDbContext(DbContextOptions<SpendDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().ToTable("MyTable");
        }

    }
}
