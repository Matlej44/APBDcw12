using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class WardSearchDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public WardSearchDTO(Ward ward)
    {
        Id = ward.Id;
        Name = ward.Name;
        Description = ward.Description;
    }
}