using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public interface ISpecializationRepository
    {
        Specialization? Get(Guid id);
        IQueryable<Specialization> GetByIds(IEnumerable<Guid> ids);
    }
}
