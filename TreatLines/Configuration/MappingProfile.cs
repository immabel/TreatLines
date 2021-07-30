using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Auth;
using TreatLines.BLL.DTOs.Hospital;
using TreatLines.BLL.DTOs.HospitalAdmin;
using TreatLines.BLL.DTOs.HospitalCreate;
using TreatLines.DAL.Entities;
using TreatLines.Models;
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
            CreateMap<RequestToCreateHospitalViewDTO, RequestToCreateHospitalModelView>()
                .ForMember(
                dest => dest.DateOfRequestCreation,
                opt => opt.MapFrom(src => src.DateOfRequestCreation.ToString("g")));

            CreateMap<Hospital, HospitalInfoDTO>()
                .ForMember(
                dest => dest.RegisterDate,
                opt => opt.MapFrom(src => src.RegisterDateTime.ToString("d")))
                .ForMember(
                dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.CreationDate.ToString("d")));
            CreateMap<HospitalInfoDTO, HospitalModel_UserControler>();

            CreateMap<HospitalAdminContactInfoDTO, HospitalAdminContactInfoModel>();
        }
    }
}
