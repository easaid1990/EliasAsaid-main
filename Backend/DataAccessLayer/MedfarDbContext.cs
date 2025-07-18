using Medfar.Interview.Types;
using Microsoft.EntityFrameworkCore;

namespace Medfar.Interview.DAL
{
    public class MedfarDbContext(DbContextOptions<MedfarDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<IndividualMessage> IndividualMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.id);
            modelBuilder.Entity<IndividualMessage>().ToTable("IndividualMessage");
            modelBuilder.Entity<IndividualMessage>().HasKey(m => m.Id);
            // Add further configuration if needed
        }
    }
}
