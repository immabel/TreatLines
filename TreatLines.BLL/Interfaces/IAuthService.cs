using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;

namespace TreatLines.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<RegistrationResponseDTO> RegisterHospitalAdminAsync(HospitalAdminRegistrationDTO request);
        Task<RegistrationResponseDTO> RegisterDoctorAsync(DoctorRegistrationDTO request);
        Task<RegistrationResponseDTO> RegisterPatientAsync(PatientRegistrationDTO request);
    }
}