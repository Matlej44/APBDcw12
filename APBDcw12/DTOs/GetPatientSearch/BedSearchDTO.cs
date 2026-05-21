using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class BedSearchDTO
{
    public int Id { get; set; }
    public BedTypeSearchDTO BedType { get; set; }
    public RoomSearchDTO Room { get; set; }

    public BedSearchDTO(Bed bed)
    {
        Id = bed.Id;
        BedType = new BedTypeSearchDTO(bed.BedType);
        Room = new RoomSearchDTO(bed.Room);
    }
}