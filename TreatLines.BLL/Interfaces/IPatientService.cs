using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Appointment;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.Prescription;

namespace TreatLines.BLL.Interfaces
{
    public interface IPatientService
    {
        Task<PatientInfoDTO> GetPatientInfoAsync(string id);
        Task<PatientInfoDTO> GetPatientInfoByEmailAsync(string email);
        Task UpdatePatientAsync(PatientInfoDTO patient);
        IEnumerable<string> GetPatientsEmailsByHospitalId(int id);
    }
}
