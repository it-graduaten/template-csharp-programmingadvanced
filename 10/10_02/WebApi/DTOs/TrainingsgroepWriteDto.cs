using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class TrainingsgroepWriteDto
{
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Naam { get; set; } = string.Empty;

    [Required]
    [StringLength(15, MinimumLength = 2)]
    public string Dag { get; set; } = string.Empty;

    [Range(1, 80)]
    public int MaximumLeden { get; set; }
}
