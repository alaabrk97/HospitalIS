using AutoMapper;
using HospitalInfoSystem.Application.Features.Palients.Command.CreatePalient;
using HospitalInfoSystem.Application.Features.Palients.Command.DeletePalient;
using HospitalInfoSystem.Application.Features.Palients.Quries.GetPatientList;
using HospitalInfoSystem.Application.Features.Palients.Quries.GetPalientDetail;
using HospitalIS.Domain;
using HospitalInfoSystem.Application.Features.Palients.Command.UpdatePalient;

namespace HospitalInfoSystem.Application.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, DeletePatientCommand>().ReverseMap();
            CreateMap<Patient, GetPatientsListViewModel>().ReverseMap();
            CreateMap<Patient, GetPatientDetailViewModel>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();

        }
    }
}
