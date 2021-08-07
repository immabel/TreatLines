using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.DAL.Entities;

namespace TreatLines.BLL.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleInfoDTO> GetScheduleInfoByIdAsync(int scheduleId);
        IEnumerable<ScheduleInfoDTO> GetSchedules(int hospitalId);
        Task<int> AddScheduleAsync(ScheduleDTO scheduleDto);
        Task<Schedule> GetByIdAsync(int id);
        Task<Schedule> FindByDescription(string start, string end, string nums);
        string FromDaysToNumbers(IList<string> days);
        List<string> FromNumbersToDays(string numbers);
    }
}
