using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class ThingsContext : DbContext
    {
        public ThingsContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CreationDate)
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Thing>()
                .Property(t => t.CreationDate)
                .HasDefaultValue(DateTime.UtcNow);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
