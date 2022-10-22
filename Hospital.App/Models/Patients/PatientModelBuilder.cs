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

        public PatientModelBuilder(IPatientRepository patientRepository, IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }

        public async Task<PageModel<PatientListItemModel>> GetAsync(OrderingForm orderingForm, int itemsCount, int page)
        {
            var patients = patientRepository.Get();

            var patientsCount = patients.Count();
            if (!string.IsNullOrEmpty(orderingForm.FieldName) && orderingForm.IsAscending.HasValue)
            {
                patients = patients.OrderBy(orderingForm.FieldName, orderingForm.IsAscending.Value);
            }
            var patientsList = await patients.Skip(itemsCount * (page - 1))
                .Take(itemsCount)
                .ToListAsync();
            var patientsModels = patientsList.Select(patient => mapper.Map<PatientListItemModel>(patient))
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
