using Microsoft.EntityFrameworkCore;

namespace Hopital.DataLayer.Context
{
    public class DefaultReadDbContext<TIEntity> : IReadDbContext<TIEntity>, IDisposable
    {
        private readonly DbContext dbContext;

        public DefaultReadDbContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class, TIEntity
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }
    }
}
