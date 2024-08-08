using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class RezerveContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=DESKTOP-V5O43QE; database=RezervDb; integrated security=true; encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<User>().HasMany(u => u.Appointments).WithOne(a => a.User).HasForeignKey(a => a.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
