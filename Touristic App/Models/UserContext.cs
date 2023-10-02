using Microsoft.EntityFrameworkCore;
using Touristic_App.Models;

namespace Touristic_App.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Guides { get; set; } = null!;

        public DbSet<Tour>? TourVM { get; set; }

    }

}
