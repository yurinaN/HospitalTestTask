using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public interface IHealthLocalityRepository
    {
        HealthLocality Get(Guid id);
    }
}
