using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Interfaces;

namespace TreatLines.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> scheduleRepository;

        private readonly IMapper mapper;

        public ScheduleService(
            IRepository<Schedule> scheduleRepository,
            IMapper mapper)
        {
            this.scheduleRepository = scheduleRepository;
            this.mapper = mapper;
        }

        public async Task<ScheduleInfoDTO> GetScheduleInfoByIdAsync(int scheduleId)
        {
            var schedule = await scheduleRepository.GetByIdAsync(scheduleId);
            var result = new ScheduleInfoDTO
            {
                StartTime = schedule.StartTime.ToString("t"),
                EndTime = schedule.EndTime.ToString("t"),
                WorkDays = FromNumbersToDays(schedule.WorkDays)
            };
            return result;
        }

        public IEnumerable<ScheduleInfoDTO> GetSchedules(int hospitalId)
        {
            var schedules = scheduleRepository
                .Find(sched => sched.HospitalId == hospitalId)
                .Result
                .Select(sch => new ScheduleInfoDTO
                {
                    Id = sch.Id,
                    StartTime = sch.StartTime.ToString("f"),
                    EndTime = sch.EndTime.ToString("f"),
                    WorkDays = FromNumbersToDays(sch.WorkDays)
                });
            return schedules;
        }

        public async Task<int> AddScheduleAsync(ScheduleDTO scheduleDto)
        {
            var schedule = mapper.Map<Schedule>(scheduleDto);
            await scheduleRepository.AddAsync(schedule);
            await scheduleRepository.SaveChangesAsync();
            return schedule.Id;
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            return await scheduleRepository.GetByIdAsync(id);
        }

        public async Task<Schedule> FindByDescription(string start, string end, string nums)
        {
            var schedules = await scheduleRepository
                .Find(sch => sch.StartTime.ToString("t").CompareTo(start) == 0
                && sch.EndTime.ToString("t").CompareTo(end) == 0
                && sch.WorkDays.CompareTo(nums) == 0);
            if (schedules.Count() > 0)
                return schedules.First();
            else
                return null;
        }

        public string FromDaysToNumbers(IList<string> days)
        {
            string nums = "";
            foreach(string day in days)
            {
                switch (day)
                {
                    case "Monday":
                        nums += "0";
                        break;
                    case "Tuesday":
                        nums += "1";
                        break;
                    case "Wednesday":
                        nums += "2";
                        break;
                    case "Thursday":
                        nums += "3";
                        break;
                    case "Friday":
                        nums += "4";
                        break;
                    case "Saturday":
                        nums += "5";
                        break;
                    case "Sunday":
                        nums += "6";
                        break;
                    default:
                        break;
                }
            }
            return nums;
        }

        public List<string> FromNumbersToDays(string numbers)
        {
            List<string> days = new List<string>();
            foreach (char num in numbers)
            {
                switch (num)
                {
                    case '0':
                        days.Add("Monday");
                        break;
                    case '1':
                        days.Add("Tuesday");
                        break;
                    case '2':
                        days.Add("Wednesday");
                        break;
                    case '3':
                        days.Add("Thursday");
                        break;
                    case '4':
                        days.Add("Friday");
                        break;
                    case '5':
                        days.Add("Saturday");
                        break;
                    case '6':
                        days.Add("Sunday");
                        break;
                    default:
                        break;
                }
            }
            return days;
        }
    }
}
