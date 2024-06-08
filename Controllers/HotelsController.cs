using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    [Authorize]
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HotelsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return View(hotels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int hotelId, DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkInDate == default || checkOutDate == default || checkInDate >= checkOutDate)
            {
                return BadRequest("Invalid check-in or check-out date.");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var order = new Order
            {
                UserId = user.Id,
                HotelId = hotelId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                OrderDate = DateTime.Now,
                CancellationRequested = false
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("MyOrders");
        }

        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var orders = await _context.Orders
                .Include(o => o.Hotel)
                .Where(o => o.UserId == user.Id)
                .ToListAsync();

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> RequestCancellation(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user.Id);

            if (order == null)
            {
                return NotFound();
            }

            var cancelRequest = new CancelRequest
            {
                OrderId = order.Id,
                RequestDate = DateTime.Now
            };

            _context.CancelRequests.Add(cancelRequest);
            order.CancellationRequested = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("MyOrders");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(hotel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving hotel: " + ex.Message);
                    ModelState.AddModelError("", "Error saving hotel");
                }
            }
            else
            {
                // Logowanie błędów walidacji
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
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
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving hotel: " + ex.Message);
                    ModelState.AddModelError("", "Error saving hotel");
                }
            }
            else
            {
                // Logowanie błędów walidacji
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            return View(hotel);
        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
