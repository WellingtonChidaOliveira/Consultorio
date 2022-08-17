using AutoMapper;
using Consultorio.Models.PatientDto.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Models.Dtos.ProfessionalDto;
using Consultorio.Models.Dtos.SpecialityDto;
using Consultorio.Models.Dtos.ScheduleDto;

namespace Consultorio.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Patient, PatientDetailsDto>().ReverseMap();
            CreateMap<Patient, PatientsDto>().ReverseMap();

            CreateMap<AppointmentDto, Appointment>()
                .ForMember(dest => dest.Professional, opt => opt.Ignore())
                .ForMember(dest => dest.Speciality, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.Speciality.Name))
                .ForMember(dest => dest.Professional, opt => opt.MapFrom(src => src.Professional.Name));

            CreateMap<Appointment, ScheduleDetailsDto>();
            CreateMap<AddScheduleDto, Appointment>();
            CreateMap<UpdateScheduleDto, Appointment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //CreateMap<AddPatientDto, Patient>();
            CreateMap<AddPatientDto, Patient>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Professional, ProfessionalDetailsDto>()
                .ForMember(dest => dest.TotalAppointments, opt => opt.MapFrom(src => src.Appointments.Count()))
                .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src =>
                src.Specialties.Select(x => x.Name).ToArray()));
            CreateMap<Professional, ProfessionalsDto>();

            CreateMap<AddProfessionalDto, Professional>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Speciality, SpecialityDetailsDto>();
            CreateMap<Speciality, SpecialitiesDto>();
            CreateMap<AddSpecialityDto, Speciality>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
