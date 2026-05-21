using APBDcw12.DTOs;

namespace APBDcw12.Services;

public interface IPatientService
{
    public Task<PatientSearchDTO> GetPatientAsync(string? search);
}