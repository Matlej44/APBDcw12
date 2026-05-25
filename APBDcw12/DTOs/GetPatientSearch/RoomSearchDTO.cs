using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class RoomSearchDTO
{
    public string Id { get; set; }
    public bool HasTv { get; set; }
    public WardSearchDTO Ward { get; set; }
    

    
}