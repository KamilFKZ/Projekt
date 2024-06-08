using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CancelRequest> CancelRequests { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "The Ritz London", City = "Londyn", Address = "150 Piccadilly, St. James's, London W1J 9BR", PricePerNight = 500m, ImageUrl = "/images/1.jpg" },
                new Hotel { Id = 2, Name = "Hotel de Paris Monte-Carlo", City = "Monte-Carlo", Address = "Place du Casino, 98000 Monte-Carlo", PricePerNight = 700m, ImageUrl = "/images/2.jpg" },
                new Hotel { Id = 3, Name = "Le Bristol Paris", City = "Paryż", Address = "112 Rue du Faubourg Saint-Honoré, 75008 Paris", PricePerNight = 800m, ImageUrl = "/images/3.jpg" },
                new Hotel { Id = 4, Name = "Hotel Sacher Wien", City = "Wiedeń", Address = "Philharmoniker Str. 4, 1010 Wien", PricePerNight = 600m, ImageUrl = "/images/4.jpg" },
                new Hotel { Id = 5, Name = "Adlon Kempinski Berlin", City = "Berlin", Address = "Unter den Linden 77, 10117 Berlin", PricePerNight = 550m, ImageUrl = "/images/5.jpg" },
                new Hotel { Id = 6, Name = "Hotel Danieli", City = "Wenecja", Address = "Riva degli Schiavoni, 4196, 30122 Venezia", PricePerNight = 650m, ImageUrl = "/images/6.jpg" },
                new Hotel { Id = 7, Name = "Four Seasons Hotel George V", City = "Paryż", Address = "31 Avenue George V, 75008 Paris", PricePerNight = 850m, ImageUrl = "/images/7.jpg" },
                new Hotel { Id = 8, Name = "The Westin Excelsior", City = "Rzym", Address = "Via Vittorio Veneto, 125, 00187 Roma", PricePerNight = 450m, ImageUrl = "/images/8.jpg" },
                new Hotel { Id = 9, Name = "Claridge's", City = "Londyn", Address = "Brook St, Mayfair, London W1K 4HR", PricePerNight = 500m, ImageUrl = "/images/9.jpg" },
                new Hotel { Id = 10, Name = "The Balmoral", City = "Edynburg", Address = "1 Princes St, Edinburgh EH2 2EQ", PricePerNight = 400m, ImageUrl = "/images/10.jpg" }
            );
        }
    }
}
