using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class AdmissionsSearchDTO
{
    public int Id { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public WardSearchDTO Ward { get; set; }
}