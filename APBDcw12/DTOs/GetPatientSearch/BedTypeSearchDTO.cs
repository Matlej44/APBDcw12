using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class BedTypeSearchDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public BedTypeSearchDTO(BedType bedType)
    {
        Id = bedType.Id;
        Name = bedType.Name;
        Description = bedType.Description;
    }
}