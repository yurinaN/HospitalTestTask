using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public class CabinetRepository : ICabinetRepository
    {
        private readonly IReadDbContext<IHospitalEntity> readHospital;

        public CabinetRepository(IReadDbContext<IHospitalEntity> readHospital)
        {
            this.readHospital = readHospital;
        }

        public Cabinet? Get(Guid id)
        {
            return readHospital.Get<Cabinet>()
                .FirstOrDefault(cabinet => cabinet.Id == id);
        }

        public IQueryable<Cabinet> GetByIds(IEnumerable<Guid> ids)
        {
            return readHospital.Get<Cabinet>()
                .Where(cabinet => ids.Contains(cabinet.Id));
        }
    }
}
