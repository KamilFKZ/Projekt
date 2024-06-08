using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CancelRequests()
        {
            var requests = await _context.CancelRequests
                .Include(c => c.Order)
                .ThenInclude(o => o.Hotel)
                .Include(c => c.Order.User) // Include user information
                .ToListAsync();

            return View(requests);
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders
                .Include(o => o.Hotel)
                .Include(o => o.User) // Include user information
                .ToListAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCancellation(int id)
        {
            var request = await _context.CancelRequests
                .Include(c => c.Order)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            var order = request.Order;
            order.IsCanceled = true; // Set cancel status
            _context.Orders.Update(order); // Update the order
            _context.CancelRequests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("CancelRequests");
        }

        [HttpPost]
        public async Task<IActionResult> DenyCancellation(int id)
        {
            var request = await _context.CancelRequests
                .Include(c => c.Order)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            request.Order.CancellationRequested = false;
            _context.CancelRequests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("CancelRequests");
        }

        public IActionResult Index()
        {
            var hotels = _context.Hotels.ToList();
            return View(hotels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }
    }
}
