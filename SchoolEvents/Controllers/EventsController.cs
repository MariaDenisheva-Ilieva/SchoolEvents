using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolEvents.Data;
using SchoolEvents.Models;

namespace SchoolEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly SchoolEventsDbContext _context;

        public EventsController(SchoolEventsDbContext context)
        {
            _context = context;
        }

        // READ - показва всички събития
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Organizer)
                .ToListAsync();

            return View(events);
        }

        // DETAILS - показва информация за избрано събитие
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // CREATE - показва формата за създаване
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _context.Categories,
                "Id",
                "Name");

            ViewBag.Organizers = new SelectList(
                _context.Organizers,
                "Id",
                "Name");

            return View();
        }

        // CREATE - записва новото събитие
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                eventModel.CategoryId);

            ViewBag.Organizers = new SelectList(
                _context.Organizers,
                "Id",
                "Name",
                eventModel.OrganizerId);

            return View(eventModel);
        }

        // EDIT - показва формата с текущите данни
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Events.FindAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                eventModel.CategoryId);

            ViewBag.Organizers = new SelectList(
                _context.Organizers,
                "Id",
                "Name",
                eventModel.OrganizerId);

            return View(eventModel);
        }

        // EDIT - записва промените
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventModel)
        {
            if (id != eventModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Events.Update(eventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(eventModel.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                eventModel.CategoryId);

            ViewBag.Organizers = new SelectList(
                _context.Organizers,
                "Id",
                "Name",
                eventModel.OrganizerId);

            return View(eventModel);
        }

        // DELETE - показва страницата за потвърждение
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // DELETE - изтрива събитието от базата
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);

            if (eventModel != null)
            {
                _context.Events.Remove(eventModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Проверява дали събитието съществува
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}