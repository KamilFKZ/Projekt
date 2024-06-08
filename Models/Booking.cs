using System.ComponentModel.DataAnnotations;
using Projekt.Models;
public class Booking
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public User User { get; set; } = new User();

    [Required]
    public Hotel Hotel { get; set; } = new Hotel();
}
