using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class PatientSearchDTO
{
    public string Pesel  { get; set; }
    public string FirstName  { get; set; }
    public string LastName  { get; set; }
    public int Age {get; set;}
    public bool Sex {get; set;}
    public List<AdmissionsSearchDTO> Admissions { get; set; } = [];
    
    public List<BedAssignmentSearchDTO>  BedAssignments { get; set; } = [];

    public PatientSearchDTO(Patient patient)
    {
        Pesel = patient.Pesel;
        FirstName = patient.FirstName;
        LastName = patient.LastName;
        Age = patient.Age;
        Sex = patient.Sex;
        foreach (var admission in patient.Admissions)
        {
            Admissions.Add(new AdmissionsSearchDTO(admission));
        }

        foreach (var bedAssignment in patient.BedAssignments)
        {
            BedAssignments.Add(new BedAssignmentSearchDTO(bedAssignment));
        }
    }
}