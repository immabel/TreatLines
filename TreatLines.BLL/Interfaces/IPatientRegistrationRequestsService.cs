using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.PatientCreate;

namespace TreatLines.BLL.Interfaces
{
    public interface IPatientRegistrationRequestsService
    {
        Task AddRequestAsync(RequestToCreatePatientDTO creationInfo);
        Task<IEnumerable<RequestToCreatePatientViewDTO>> GetAllRequestsAsync();
        Task ApproveRequestAsync(int id);
        Task RejectRequestAsync(int id);
    }
}
