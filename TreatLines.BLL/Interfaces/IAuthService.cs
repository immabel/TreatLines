using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;

namespace TreatLines.BLL.Interfaces
{
    public interface IAuthService
    {
        Task RegisterHospitalAdminAsync(HospitalAdminRegistrationDTO request);
        Task RegisterDoctorAsync(DoctorRegistrationDTO request);
        Task RegisterPatientAsync(PatientRegistrationDTO request);
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);
    }
}