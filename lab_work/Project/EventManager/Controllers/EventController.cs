using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManager.Data;
using EventManager.Models;
using EventManager.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly BookingService _service;

        public EventController(AppDbContext context)
        {
            _context = context;
            _service = new BookingService();
        }

        // Show all events
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // Filter upcoming events (Lambda)
        public IActionResult Upcoming()
        {
            var upcomingEvents = _context.Events
                .Where(e => e.Date > DateTime.Now)
                .ToList();

            return View(upcomingEvents);
        }

        // Create event
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event e)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(e);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(e);
        }
        // ================================
// EDIT EVENT
// ================================
public async Task<IActionResult> Edit(int id)
{
    var ev = await _context.Events.FindAsync(id);
    if (ev == null) return NotFound();

    return View(ev);
}

[HttpPost]
public async Task<IActionResult> Edit(Event e)
{
    if (ModelState.IsValid)
    {
        _context.Events.Update(e);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    return View(e);
}

// ================================
// DELETE EVENT
// ================================
public async Task<IActionResult> Delete(int id)
{
    var ev = await _context.Events.FindAsync(id);
    if (ev == null) return NotFound();

    return View(ev);
}

[HttpPost, ActionName("Delete")]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var ev = await _context.Events.FindAsync(id);

    if (ev != null)
    {
        _context.Events.Remove(ev);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction("Index");
}
        // Book event
        public async Task<IActionResult> Book(int id, int quantity)
        {
            var ev = await _context.Events.FindAsync(id);

            if (ev == null)
                return NotFound();

            if (ev.AvailableSeats < quantity)
                return Content("Not enough seats");

            int total = _service.CalculateTotalPrice(ev.TicketPrice, quantity);

            ev.AvailableSeats -= quantity;

            _context.Bookings.Add(new Booking
            {
                EventId = id,
                TicketsBooked = quantity,
                UserName = "TestUser"
            });

            await _context.SaveChangesAsync();

            return Content($"Booked Successfully! Total Price: {total}");
        }
    }
}
