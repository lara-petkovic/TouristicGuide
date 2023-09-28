using Microsoft.EntityFrameworkCore;

namespace Touristic_App.Models
{
    public class GuideContext : DbContext
    {
        public GuideContext(DbContextOptions<GuideContext> options) : base(options) { }

        public DbSet<Guide> Guides { get; set; } = null!;

    }

}
