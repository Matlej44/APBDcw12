using APBDcw12.Data;
using APBDcw12.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBDcw12.Services;

public class PatientService : IPatientService
{
    private readonly DatabaseFirstContext _dbcontext;

    public PatientService(DatabaseFirstContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<List<PatientSearchDTO>> GetPatientAsync(string? search)
    {
        var canConnectAsync = await _dbcontext.Database.CanConnectAsync();
        if (!canConnectAsync)
        {
            throw new Exception("Database connection is not available");
        }

        var patient = await _dbcontext.Patients
            .Where(patient1 => patient1.FirstName.Contains(search ?? "") || patient1.LastName.Contains(search ?? ""))
            .Include(patient1 => patient1.Admissions)
            .ThenInclude(admission => admission.Ward)
            .Include(patient1 => patient1.BedAssignments)
            .ThenInclude(assignment => assignment.Bed)
            .ThenInclude(bed => bed.Room)
            .ThenInclude(room => room.Ward)
            .Include(patient1 => patient1.BedAssignments)
            .ThenInclude(assignment => assignment.Bed)
            .ThenInclude(bed => bed.BedType).Select(a => new PatientSearchDTO(a)).ToListAsync();
        return patient;
    }
}