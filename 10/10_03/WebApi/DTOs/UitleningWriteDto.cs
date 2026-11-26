using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class UitleningWriteDto
{
    [Range(1, int.MaxValue)]
    public int MateriaalId { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Uitlener { get; set; } = string.Empty;

    [Range(1, 30)]
    public int AantalDagen { get; set; }
}
