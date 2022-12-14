using AutoMapper;
using Hopital.DataLayer.Entities;
using Hospital.App.Models.Doctors;
using Hospital.App.Models.Patients;

namespace Hospital.App
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Patient, PatientItemModel>();
            CreateMap<Patient, PatientListItemModel>();
            CreateMap<PatientForm, Patient>();
            CreateMap<Doctor, DoctorItemModel>();
            CreateMap<DoctorForm, Doctor>();
        }
    }
}
