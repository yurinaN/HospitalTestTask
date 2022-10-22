using AutoMapper;
using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;
using Hopital.DataLayer.Repositories;
using Hospital.Core.Extentions;

namespace Hospital.App.Models.Patients
{
    public class PatientModelHandler : IPatientModelHandler
    {
        private readonly IPatientRepository patientRepository;
        private readonly IWriteDbContext<IHospitalEntity> writeHospital;
        private readonly IMapper mapper;
        private readonly IHealthLocalityRepository healthLocalityRepository;

        public PatientModelHandler(IPatientRepository patientRepository,
            IWriteDbContext<IHospitalEntity> writeHospital,
            IMapper mapper,
            IHealthLocalityRepository healthLocalityRepository)
        {
            this.patientRepository = patientRepository;
            this.writeHospital = writeHospital;
            this.mapper = mapper;
            this.healthLocalityRepository = healthLocalityRepository;
        }

        public void Create(PatientForm form)
        {
            var healthLocality = healthLocalityRepository.Get(form.HealthLocalityId);
            if (healthLocality == null) throw new NotFoundException();

            var patient = mapper.Map<Patient>(form);
            writeHospital.Add(patient);
            writeHospital.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var patient = patientRepository.Get(id);
            if (patient == null) throw new NotFoundException();

            writeHospital.Remove(patient);
            writeHospital.SaveChanges();
        }

        public void Edit(Guid id, PatientForm form)
        {
            var patient = patientRepository.Get(id);
            if (patient == null) throw new NotFoundException();

            var healthLocality = healthLocalityRepository.Get(form.HealthLocalityId);
            if (healthLocality == null) throw new NotFoundException();

            writeHospital.Attach(patient);
            patient.Surmane = form.Surmane;
            patient.Name = form.Name;
            patient.Patronymic = form.Patronymic;
            patient.Address = form.Address;
            patient.Birthday = form.Birthday;
            patient.Gender = form.Gender;
            patient.HealthLocalityId = form.HealthLocalityId;
            writeHospital.SaveChanges();
        }
    }
}
