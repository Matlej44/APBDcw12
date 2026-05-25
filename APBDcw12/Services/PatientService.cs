using APBDcw12.Data;
using APBDcw12.DTOs;
using APBDcw12.DTOs.CreateBedAssigment;
using APBDcw12.Exception;
using APBDcw12.Models;
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
        var result = await _dbcontext.Patients
            .Where(patient1 => patient1.FirstName.Contains(search ?? "") || patient1.LastName.Contains(search ?? ""))
            .Select(a => new PatientSearchDTO
            {
                Pesel = a.Pesel,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Age = a.Age,
                Sex = a.Sex ? "Male" : "Female",
                Admissions = a.Admissions.Select(admission => new AdmissionsSearchDTO
                {
                    Id = admission.Id,
                    AdmissionDate = admission.AdmissionDate,
                    DischargeDate = admission.DischargeDate,
                    Ward = new WardSearchDTO
                    {
                        Id = admission.WardId,
                        Name = admission.Ward.Name,
                        Description = admission.Ward.Description
                    }
                }).ToList(),
                BedAssignments = a.BedAssignments.Select(ba => new BedAssignmentSearchDTO
                {
                    Id = ba.Id,
                    From = ba.From,
                    To = ba.To,
                    Bed = new BedSearchDTO
                    {
                        Id = ba.BedId,
                        BedType = new BedTypeSearchDTO
                        {
                            Id = ba.Bed.BedTypeId,
                            Name = ba.Bed.BedType.Name,
                            Description = ba.Bed.BedType.Description
                        },
                    }
                }).ToList()
            }).ToListAsync();

        return result;
    }

    public async Task AddBedAssignmentAsync(string pesel, CreateBedAssigmentDTO bedAssignment)
    {
        var patient = await _dbcontext.Patients.FirstOrDefaultAsync(a => a.Pesel == pesel);
        if (patient == null) throw new NotFoundException("Patient not found");

        var bed = await _dbcontext.Beds
            .Where(a => (bedAssignment.BedType == null || a.BedType.Name == bedAssignment.BedType)
                        && a.Room.Ward.Name == bedAssignment.Ward
                        && !a.BedAssignments.Any(ba => 
                                (bedAssignment.To == null || ba.From < bedAssignment.To) && 
                                (ba.To == null || ba.To > bedAssignment.From)))
            .FirstOrDefaultAsync();
        if (bed == null) throw new NotFoundException("No available bed");

        var bedAssigmentCreation = new BedAssignment
        {
            Bed = bed,
            From = bedAssignment.From,
            To = bedAssignment.To,
            PatientPesel = pesel
        };
        await _dbcontext.BedAssignments.AddAsync(bedAssigmentCreation);
        await _dbcontext.SaveChangesAsync();
    }
}