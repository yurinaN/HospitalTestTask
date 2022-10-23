using Hopital.DataLayer.Repositories;
using Hospital.Core.Models.Common;
using Hospital.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Hospital.Core.Extentions;
using AutoMapper;

namespace Hospital.App.Models.Doctors
{
    public class DoctorModelBuilder : IDoctorModelBuilder
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly ICabinetRepository cabinetRepository;
        private readonly IHealthLocalityRepository healthLocalityRepository;
        private readonly ISpecializationRepository specializationRepository;
        private readonly IMapper mapper;

        public DoctorModelBuilder(IDoctorRepository doctorRepository,
            ICabinetRepository cabinetRepository,
            IHealthLocalityRepository healthLocalityRepository,
            ISpecializationRepository specializationRepository,
            IMapper mapper)
        {
            this.doctorRepository = doctorRepository;
            this.cabinetRepository = cabinetRepository;
            this.healthLocalityRepository = healthLocalityRepository;
            this.specializationRepository = specializationRepository;
            this.mapper = mapper;
        }

        public DoctorItemModel Get(Guid id)
        {
            var doctor = doctorRepository.Get(id);
            if (doctor == null) throw new NotFoundException();

            return mapper.Map<DoctorItemModel>(doctor);
        }

        public async Task<PageModel<DoctorListItemModel>> GetAsync(DoctorGetListParamsModel paramsModel)
        {
            var doctors = doctorRepository.Get();

            var doctorsCount = doctors.Count();
            if (!string.IsNullOrEmpty(paramsModel.FieldName))
            {
                doctors = doctors.OrderBy(paramsModel.FieldName, paramsModel.IsAscending ?? false);
            }
            var doctorsList = await doctors.Skip(paramsModel.ItemsCount * (paramsModel.Page - 1))
                .Take(paramsModel.ItemsCount)
                .ToListAsync();
            var cabinets = await cabinetRepository.GetByIds(doctorsList.Select(list => list.CabinetId))
                .ToListAsync();
            var specializations = await specializationRepository.GetByIds(doctorsList.Select(list => list.SpecializationId))
                .ToListAsync();
            var healthLocalities = await healthLocalityRepository.GetByIds(
                    doctorsList.Where(list => list.HealthLocalityId.HasValue).Select(list => list.HealthLocalityId!.Value))
                .ToListAsync();

            var doctorsModels = doctorsList.Select(doctor => new DoctorListItemModel(doctor.Id,
                    cabinets.FirstOrDefault(cabinet => cabinet.Id == doctor.CabinetId)!.Number,
                    specializations.FirstOrDefault(specialization => specialization.Id == doctor.SpecializationId)!.Name,
                    healthLocalities.FirstOrDefault(locality => locality.Id == doctor.HealthLocalityId)?.Number))
                .ToList();

            return new PageModel<DoctorListItemModel>(doctorsModels, doctorsCount);
        }
    }
}
