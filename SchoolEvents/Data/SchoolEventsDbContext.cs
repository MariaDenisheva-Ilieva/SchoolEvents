using Microsoft.EntityFrameworkCore;
using SchoolEvents.Models;

namespace SchoolEvents.Data
{
    public class SchoolEventsDbContext : DbContext
    {
        public SchoolEventsDbContext(
            DbContextOptions<SchoolEventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Organizer> Organizers { get; set; }
    }
}