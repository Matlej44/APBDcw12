using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class RoomSearchDTO
{
    public string Id { get; set; }
    public bool HasTv { get; set; }
    public WardSearchDTO Ward { get; set; }
    

    public RoomSearchDTO(Room room)
    {
        Id = room.Id;
        HasTv = room.HasTv;
        Ward = new WardSearchDTO(room.Ward);
    }
}