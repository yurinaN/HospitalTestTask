using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly IReadDbContext<IHospitalEntity> readHospital;

        public SpecializationRepository(IReadDbContext<IHospitalEntity> readHospital)
        {
            this.readHospital = readHospital;
        }

        public Specialization? Get(Guid id)
        {
            return readHospital.Get<Specialization>()
                .FirstOrDefault(specialization => specialization.Id == id);
        }

        public IQueryable<Specialization> GetByIds(IEnumerable<Guid> ids)
        {
            return readHospital.Get<Specialization>()
                .Where(specialization => ids.Contains(specialization.Id));
        }
    }
}
