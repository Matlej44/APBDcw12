using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class BedAssignmentSearchDTO
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public BedSearchDTO Bed { get; set; }

    public BedAssignmentSearchDTO(BedAssignment bedAssignment)
    {
        Id = bedAssignment.Id;
        From = bedAssignment.From;
        To = bedAssignment.To;
        Bed = new BedSearchDTO(bedAssignment.Bed);
        
    }
}