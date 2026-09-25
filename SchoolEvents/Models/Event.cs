using System.ComponentModel.DataAnnotations;

namespace SchoolEvents.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Location { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        [Required]
        public int OrganizerId { get; set; }

        public Organizer Organizer { get; set; } = null!;
    }
}