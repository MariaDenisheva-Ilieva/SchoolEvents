using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolEvents.Data;

namespace SchoolEvents.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly SchoolEventsDbContext _context;

        public OrganizersController(SchoolEventsDbContext context)
        {
            _context = context;
        }

        // Показва всички организатори
        public async Task<IActionResult> Index()
        {
            var organizers = await _context.Organizers
                .ToListAsync();

            return View(organizers);
        }
    }
}