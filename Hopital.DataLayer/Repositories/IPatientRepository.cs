using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public interface IPatientRepository
    {
        Patient Get(Guid id);
        IQueryable<Patient> Get();
    }
}
