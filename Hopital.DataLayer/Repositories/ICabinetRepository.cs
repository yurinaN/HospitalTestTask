using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public interface ICabinetRepository
    {
        Cabinet? Get(Guid id);
        IQueryable<Cabinet> GetByIds(IEnumerable<Guid> ids);
    }
}
