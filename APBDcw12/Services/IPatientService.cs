using APBDcw12.DTOs;
using APBDcw12.DTOs.CreateBedAssigment;

namespace APBDcw12.Services;

public interface IPatientService
{
    public Task<List<PatientSearchDTO>> GetPatientAsync(string? search);
    public Task AddBedAssignmentAsync(string pesel, CreateBedAssigmentDTO bedAssignment);
}