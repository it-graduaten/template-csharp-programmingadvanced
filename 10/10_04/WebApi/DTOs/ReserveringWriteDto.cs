using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class ReserveringWriteDto
{
    [Range(1, int.MaxValue)]
    public int ApparaatId { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Klantnaam { get; set; } = string.Empty;

    [Range(1, 14)]
    public int AantalDagen { get; set; }
}
