using AutoMapper;
using Hopital.DataLayer.Repositories;
using Hospital.Core.Extentions;
using Hospital.Core.Models.Common;
using Hospital.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Hospital.App.Models.Patients
{
    public class PatientModelBuilder : IPatientModelBuilder
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;
        private readonly IHealthLocalityRepository healthLocalityRepository;

        public PatientModelBuilder(IPatientRepository patientRepository, 
            IMapper mapper, 
            IHealthLocalityRepository healthLocalityRepository)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
            this.healthLocalityRepository = healthLocalityRepository;
        }

        public async Task<PageModel<PatientListItemModel>> GetAsync(PatientGetListParamsModel paramsModel)
        {
            var patients = patientRepository.Get();

            var patientsCount = patients.Count();
            if (!string.IsNullOrEmpty(paramsModel.FieldName))
            {
                patients = patients.OrderBy(paramsModel.FieldName, paramsModel.IsAscending ?? false);
            }
            var patientsList = await patients.Skip(paramsModel.ItemsCount * (paramsModel.Page - 1))
                .Take(paramsModel.ItemsCount)
                .ToListAsync();

            var healthLocalities = healthLocalityRepository.GetByIds(patientsList.Select(patient => patient.HealthLocalityId))
                .ToList();
            var patientsModels = patientsList.Select(patient =>
                {
                    var model = mapper.Map<PatientListItemModel>(patient);
                    model.HealthLocality = healthLocalities.FirstOrDefault(locality => locality.Id == patient.HealthLocalityId)!.Number;
                    return model;
                })
                .ToList();

            return new PageModel<PatientListItemModel>(patientsModels, patientsCount);
        }

        public PatientItemModel Get(Guid id)
        {
            var patient = patientRepository.Get(id);
            if (patient == null) throw new NotFoundException();

            return mapper.Map<PatientItemModel>(patient);
        }
    }
}
