using AutoMapper;
using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;
using Hopital.DataLayer.Repositories;
using Hospital.Core.Extentions;

namespace Hospital.App.Models.Doctors
{
    public class DoctorModelHandler : IDoctorModelHandler
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly ICabinetRepository cabinetRepository;
        private readonly ISpecializationRepository specializationRepository;
        private readonly IHealthLocalityRepository healthLocalityRepository;
        private readonly IMapper mapper;
        private readonly IWriteDbContext<IHospitalEntity> writeHospital;

        public DoctorModelHandler(IDoctorRepository doctorRepository,
            ICabinetRepository cabinetRepository,
            ISpecializationRepository specializationRepository,
            IHealthLocalityRepository healthLocalityRepository,
            IMapper mapper,
            IWriteDbContext<IHospitalEntity> writeHospital)
        {
            this.doctorRepository = doctorRepository;
            this.cabinetRepository = cabinetRepository;
            this.specializationRepository = specializationRepository;
            this.healthLocalityRepository = healthLocalityRepository;
            this.mapper = mapper;
            this.writeHospital = writeHospital;
        }

        public void Create(DoctorForm form)
        {
            var cabinet = cabinetRepository.Get(form.CabinetId);
            var specialization = specializationRepository.Get(form.SpecializationId);
            var healthLocality = form.HealthLocalityId.HasValue ? healthLocalityRepository.Get(form.HealthLocalityId.Value) : null;

            if (cabinet == null || specialization == null || healthLocality == null) 
                throw new NotFoundException();

            var doctor = mapper.Map<Doctor>(form);
            writeHospital.Add(doctor);
            writeHospital.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var doctor = doctorRepository.Get(id);
            if (doctor == null) throw new NotFoundException();

            writeHospital.Remove(doctor);
            writeHospital.SaveChanges();
        }

        public void Edit(Guid id, DoctorForm form)
        {
            var doctor = doctorRepository.Get(id);
            if (doctor == null) throw new NotFoundException();

            writeHospital.Attach(doctor);
            doctor.CabinetId = form.CabinetId;
            doctor.SpecializationId = form.SpecializationId;
            doctor.HealthLocalityId = form.HealthLocalityId;
            writeHospital.SaveChanges();
        }
    }
}
