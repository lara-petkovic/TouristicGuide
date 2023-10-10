
using Microsoft.EntityFrameworkCore;

namespace TouristicGuide.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<Location> Locations { get; set; }
        //public DbSet<Tour> Tours { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
