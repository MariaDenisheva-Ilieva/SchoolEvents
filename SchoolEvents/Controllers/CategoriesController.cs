using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolEvents.Data;

namespace SchoolEvents.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly SchoolEventsDbContext _context;

        public CategoriesController(SchoolEventsDbContext context)
        {
            _context = context;
        }

        // Показва всички категории
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .ToListAsync();

            return View(categories);
        }
    }
}