using APBDcw12.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBDcw12.Services;

public class PatientService : IPatientService
{
    private readonly DbContext _dbcontext;

    public PatientService(DbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<PatientSearchDTO> GetPatientAsync(string? search)
    {
        var canConnectAsync = await _dbcontext.Database.CanConnectAsync();
        if (!canConnectAsync)
        {
            throw new Exception("Database connection is not available");
        }
        
    }
}