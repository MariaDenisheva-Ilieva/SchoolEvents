using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SchoolEvents.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Заглавието трябва да бъде между 3 и 100 символа.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(1000, MinimumLength = 10,
            ErrorMessage = "Описанието трябва да бъде между 10 и 1000 символа.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Датата и часът са задължителни.")]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Мястото е задължително.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Мястото трябва да бъде между 3 и 100 символа.")]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "Изберете категория.")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        [Required(ErrorMessage = "Изберете организатор.")]
        public int OrganizerId { get; set; }

        [ValidateNever]
        public Organizer Organizer { get; set; } = null!;
    }
}