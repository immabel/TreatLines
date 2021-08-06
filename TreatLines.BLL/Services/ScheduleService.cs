using AutoMapper;
using System;
using System.Collections.Generic;
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

        IMapper mapper;

        public ScheduleService(
            IRepository<Schedule> scheduleRepository,
            IMapper mapper)
        {
            this.scheduleRepository = scheduleRepository;
            this.mapper = mapper;
        }

        public async Task<ScheduleInfoDoctorDTO> GetScheduleByIdAsync(int scheduleId)
        {
            var schedule = await scheduleRepository.GetByIdAsync(scheduleId);
            return mapper.Map<ScheduleInfoDoctorDTO>(schedule);
        }

        public async Task<IEnumerable<ScheduleInfoDoctorDTO>> GetSchedules(int hospitalId)
        {
            var schedules = await scheduleRepository.Find(sched => sched.Doctors.Exists(doc => doc.HospitalId == hospitalId));
            return mapper.Map<IEnumerable<ScheduleInfoDoctorDTO>>(schedules);
        }

        public async Task<int> AddScheduleAsync(ScheduleDTO scheduleDto)
        {
            var schedule = mapper.Map<Schedule>(scheduleDto);
            await scheduleRepository.AddAsync(schedule);
            await scheduleRepository.SaveChangesAsync();
            return schedule.Id;
        }

        public async Task UpdateSchedule(ScheduleInfoDoctorDTO scheduleDto)
        {
            Schedule schedule = await scheduleRepository.GetByIdAsync(scheduleDto.Id);
            schedule.StartTime = DateTimeOffset.Parse(scheduleDto.StartTime);
            schedule.EndTime = DateTimeOffset.Parse(scheduleDto.EndTime);
            schedule.WorkDays = scheduleDto.WorkDays;
            scheduleRepository.Update(schedule);
            await scheduleRepository.SaveChangesAsync();
        }
    }
}
