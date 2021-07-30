using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.HospitalCreate;

namespace TreatLines.BLL.Interfaces
{
    public interface IHospitalRegistrationRequestsService
    {
        Task<HospitalCreationResultDTO> CreateHospitalAsync(RequestToCreateHospitalDTO createRequestDTO);
        Task AddRequestAsync(RequestToCreateHospitalDTO creationInfo);
        Task<IEnumerable<RequestToCreateHospitalViewDTO>> GetAllRequestsAsync();
        Task ApproveRequestAsync(int id);
        Task RejectRequestAsync(int id);
    }
}
