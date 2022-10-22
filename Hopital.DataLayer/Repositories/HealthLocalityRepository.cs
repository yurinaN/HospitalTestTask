using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public class HealthLocalityRepository : IHealthLocalityRepository
    {
        private readonly IReadDbContext<IHospitalEntity> readHospital;

        public HealthLocalityRepository(IReadDbContext<IHospitalEntity> readHospital)
        {
            this.readHospital = readHospital;
        }

        public HealthLocality? Get(Guid id)
        {
            return readHospital.Get<HealthLocality>()
                .FirstOrDefault(locality => locality.Id == id);
        }

        public IQueryable<HealthLocality> GetByIds(IEnumerable<Guid> ids)
        {
            return readHospital.Get<HealthLocality>()
                .Where(locality => ids.Contains(locality.Id));
        }
    }
}
