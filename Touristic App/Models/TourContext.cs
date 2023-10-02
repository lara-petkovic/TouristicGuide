using Microsoft.EntityFrameworkCore;

namespace Touristic_App.Models
{
    public class TourContext : DbContext
    {
        public TourContext(DbContextOptions<TourContext> options) : base(options) { }

        public DbSet<Tour> Tours { get; set; }

        public User Guide { get; set; }
    }
}
