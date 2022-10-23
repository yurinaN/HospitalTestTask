using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public interface IDoctorRepository
    {
        IQueryable<Doctor> Get();
        Doctor? Get(Guid id);
    }
}
