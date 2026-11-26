using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class TentoonstellingWriteDto
{
    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Beschrijving { get; set; } = string.Empty;

    [Range(1, 5000)]
    public int MaximaalAantalBezoekers { get; set; }
}
