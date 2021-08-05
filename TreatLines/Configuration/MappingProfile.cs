﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.Doctor;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.BLL.DTOs.HospitalCreate;
using TreatLines.BLL.DTOs.Patient;
using TreatLines.BLL.DTOs.PatientCreate;
using TreatLines.DAL.Entities;
using TreatLines.Models;
using TreatLines.Models.ProfileInfo;
using TreatLines.Models.Requests;
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
            CreateMap<RequestToCreateHospitalViewDTO, RequestInfoToCreateHospitalModel>()
                .ForMember(
                dest => dest.DateOfRequestCreation,
                opt => opt.MapFrom(src => src.DateOfRequestCreation.ToString("g")));

            CreateMap<RequestToCreatePatientViewDTO, RequestInfoToCreatePatientModel>()
                .ForMember(
                dest => dest.DateOfRequestCreation,
                opt => opt.MapFrom(src => src.DateOfRequestCreation.ToString("g")));

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

            CreateMap<HospitalAdminInfoDTO, HospitalAdminContactInfoModel>();

            CreateMap<HospitalAdminInfoDTO, HospitalAdminModel>();

            CreateMap<DoctorInfoDTO, DoctorModel>();

            CreateMap<PatientInfoDTO, PatientModel>();
        }
    }
}
