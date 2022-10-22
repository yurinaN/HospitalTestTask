namespace Hopital.DataLayer.Context
{
    public interface IWriteDbContext<TIEntity>
    {
        void Add<TEntity>(TEntity entity) where TEntity : class, TIEntity;

        void Attach<TEntity>(TEntity entity) where TEntity : class, TIEntity;

        void Remove<TEntity>(TEntity entity) where TEntity : class, TIEntity;

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
