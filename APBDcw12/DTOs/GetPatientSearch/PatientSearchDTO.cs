using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class PatientSearchDTO
{
    public string Pesel  { get; set; }
    public string FirstName  { get; set; }
    public string LastName  { get; set; }
    public int Age {get; set;}
    public string Sex {get; set;}
    public List<AdmissionsSearchDTO> Admissions { get; set; } = [];
    
    public List<BedAssignmentSearchDTO>  BedAssignments { get; set; } = [];
}