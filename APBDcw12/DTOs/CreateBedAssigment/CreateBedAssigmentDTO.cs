using System.ComponentModel.DataAnnotations;

namespace APBDcw12.DTOs.CreateBedAssigment;

public class CreateBedAssigmentDTO
{
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public string? BedType { get; set; }
    [Required]
    public string Ward { get; set; }
}