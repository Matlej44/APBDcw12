using APBDcw12.DTOs;

namespace APBDcw12.Services;

public interface IPatientService
{
    public Task<List<PatientSearchDTO>> GetPatientAsync(string? search);
}