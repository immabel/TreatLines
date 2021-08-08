﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Admin;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.BLL.DTOs.HospitalCreate;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.PatientCreate;
using TreatLines.BLL.DTOs.Schedule;
using TreatLines.DAL.Entities;
using TreatLines.Models;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Requests;
using TreatLines.Models.Response;
using TreatLines.Models.Tables;

namespace TreatLines.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequest, LoginRequestDTO>();

            CreateMap<RequestToCreateHospitalModel, RequestToCreateHospitalDTO>();
            CreateMap<RequestToCreateHospitalDTO, RequestToCreateHospital>();
            CreateMap<RequestToCreateHospital, RequestToCreateHospitalDTO>();
            CreateMap<RequestToCreateHospital, RequestToCreateHospitalViewDTO>()
                .ForMember(
                dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.HospitalCreationDate));
            CreateMap<RequestToCreateHospitalViewDTO, RequestInfoToCreateHospitalModel>()
                .ForMember(
                dest => dest.DateOfRequestCreation,
                opt => opt.MapFrom(src => src.DateOfRequestCreation.ToString("g")))
                .ForMember(
                dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.CreationDate.ToString("d")));

            CreateMap<RequestToCreatePatient, RequestToCreatePatientViewDTO>();
            CreateMap<RequestToCreatePatientViewDTO, RequestInfoToCreatePatientModel>()
                .ForMember(
                dest => dest.DateOfRequestCreation,
                opt => opt.MapFrom(src => src.DateOfRequestCreation.ToString("g")))
                .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.LastName + ", " + src.FirstName));
            CreateMap<RequestToCreatePatientModel, RequestToCreatePatientDTO>();
            CreateMap<RequestToCreatePatientDTO, RequestToCreatePatient>();

            CreateMap<Hospital, HospitalInfoDTO>()
                .ForMember(
                dest => dest.RegisterDate,
                opt => opt.MapFrom(src => src.RegisterDateTime.ToString("d")))
                .ForMember(
                dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.CreationDate.ToString("d")))
                .ForMember(
                dest => dest.Blocked,
                opt => opt.MapFrom(src => src.Blocked ? 1 : 0));
            CreateMap<HospitalInfoDTO, HospitalModel>();

            CreateMap<HospitalInfoDTO, HospitalProfileInfoModel>().ReverseMap();
            CreateMap<AdminProfileInfoDTO, AdminProfileInfoModel>();//.ReverseMap();
            CreateMap<AdminProfileInfoModel, AdminProfileInfoDTO>();

            CreateMap<HospitalAdminInfoDTO, HospitalAdminContactInfoModel>();

            CreateMap<HospitalAdminInfoDTO, HospitalAdminModel>()
                .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.LastName + ", " + src.FirstName));
            CreateMap<HospitalAdminInfoDTO, HospitalAdminProfileInfoModel>();
            CreateMap<User, HospitalAdminInfoDTO>()
                .ForMember(
                dest => dest.RegistrationDate,
                opt => opt.MapFrom(src => src.RegistrationDate.ToString("d")))
                .ForMember(
                dest => dest.Blocked,
                opt => opt.MapFrom(src => src.Blocked ? 1 : 0))
                .ReverseMap();

            CreateMap<DoctorInfoDTO, DoctorModel>()
                .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.LastName + ", " + src.FirstName));
            CreateMap<DoctorProfileInfoDTO, DoctorProfileInfoModel>();

            CreateMap<PatientInfoDTO, PatientModel>();
            CreateMap<Patient, PatientInfoDTO>()
                .ForMember(
                dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.DateOfBirth.ToString("d")))
                .ReverseMap();

            CreateMap<ScheduleInfoModel, ScheduleInfoDoctorDTO>();
            CreateMap<ScheduleDTO, Schedule>()
                .ForMember(
                dest => dest.StartTime,
                opt => opt.MapFrom(src => DateTimeOffset.Parse(src.StartTime)))
                .ForMember(
                dest => dest.EndTime,
                opt => opt.MapFrom(src => DateTimeOffset.Parse(src.EndTime)));

            CreateMap<FreeDateTimesDTO, FreeDateTimeModel>();
        }
    }
}
