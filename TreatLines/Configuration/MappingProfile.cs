using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalCreate;
using TreatLines.DAL.Entities;
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
            CreateMap<RequestToCreateHospital, RequestToCreateHospitalViewDTO>();
            CreateMap<RequestToCreateHospitalViewDTO, RequestToCreateHospitalModelView>()
                .ForMember(
                dest => dest.DateOfRequestCreation,
                opt => opt.MapFrom(src => src.DateOfRequestCreation.ToString("g")));

            CreateMap<Hospital, HospitalViewDTO>()
                .ForMember(
                dest => dest.RegisterDateTime,
                opt => opt.MapFrom(src => src.RegisterDateTime.ToString("d")));
            CreateMap<HospitalViewDTO, HospitalModel_UserControler>();
        }
    }
}
