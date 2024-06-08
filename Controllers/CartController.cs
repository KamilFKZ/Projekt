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
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var cartItems = await _context.CartItems
                .Include(c => c.Hotel)
                .Where(c => c.UserId == user.Id)
                .ToListAsync();

            return View(cartItems);
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

            var cartItem = new CartItem
            {
                UserId = user.Id,
                HotelId = hotelId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Id);

            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var cartItems = await _context.CartItems
                .Include(c => c.Hotel)
                .Where(c => c.UserId == user.Id)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return BadRequest("Koszyk jest pusty.");
            }

            foreach (var cartItem in cartItems)
            {
                var order = new Order
                {
                    UserId = user.Id,
                    HotelId = cartItem.HotelId,
                    CheckInDate = cartItem.CheckInDate,
                    CheckOutDate = cartItem.CheckOutDate,
                    OrderDate = DateTime.Now,
                    CancellationRequested = false
                };

                _context.Orders.Add(order);
                _context.CartItems.Remove(cartItem);
            }

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
        public async Task<IActionResult> RequestCancellation(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            order.CancellationRequested = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyOrders));
        }
    }
}
