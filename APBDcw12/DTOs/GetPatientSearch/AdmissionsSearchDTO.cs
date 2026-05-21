using APBDcw12.Models;

namespace APBDcw12.DTOs;

public class AdmissionsSearchDTO
{
    public int Id { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public WardSearchDTO Ward { get; set; }

    public AdmissionsSearchDTO(Admission admission)
    {
        Id = admission.Id;
        AdmissionDate = admission.AdmissionDate;
        DischargeDate = admission.DischargeDate;
        Ward = new WardSearchDTO(admission.Ward);
    }
}