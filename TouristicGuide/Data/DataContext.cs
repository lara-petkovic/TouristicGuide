using Microsoft.EntityFrameworkCore;
using Touristic_App.Models;
using TouristicGuide.Models;

namespace TouristicGuide.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //If i have many to many classes i would need to have a class between them.The code for this you could find at https://www.youtube.com/watch?v=EmV_IBYIlyo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&index=5
        }
    }
}
