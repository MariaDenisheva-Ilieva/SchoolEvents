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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Спорт"
                },
                new Category
                {
                    Id = 2,
                    Name = "Култура"
                },
                new Category
                {
                    Id = 3,
                    Name = "Образование"
                },
                new Category
                {
                    Id = 4,
                    Name = "Технологии"
                },
                new Category
                {
                    Id = 5,
                    Name = "Благотворителност"
                }
            );

            modelBuilder.Entity<Organizer>().HasData(
                new Organizer
                {
                    Id = 1,
                    Name = "Мария Петрова",
                    Email = "maria.petrova@school.bg"
                },
                new Organizer
                {
                    Id = 2,
                    Name = "Иван Георгиев",
                    Email = "ivan.georgiev@school.bg"
                },
                new Organizer
                {
                    Id = 3,
                    Name = "Елена Димитрова",
                    Email = "elena.dimitrova@school.bg"
                },
                new Organizer
                {
                    Id = 4,
                    Name = "Георги Иванов",
                    Email = "georgi.ivanov@school.bg"
                },
                new Organizer
                {
                    Id = 5,
                    Name = "Никол Николова",
                    Email = "nikol.nikolova@school.bg"
                }
            );
        }
    }
}