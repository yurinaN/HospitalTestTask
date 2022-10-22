using Microsoft.EntityFrameworkCore;

namespace Hopital.DataLayer.Context
{
    public class DefaultWriteDbContext<TIEntity> : IWriteDbContext<TIEntity>
    {
        private readonly DbContext dbContext;

        public DefaultWriteDbContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class, TIEntity
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class, TIEntity
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbContext.Set<TEntity>().Attach(entity);
            }
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, TIEntity
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
