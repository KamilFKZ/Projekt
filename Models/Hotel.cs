using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace Projekt.Models
{ 
public class Hotel
    {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    public decimal PricePerNight { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }  // Nullable


    }
}