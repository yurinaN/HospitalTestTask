namespace Hopital.DataLayer.Context
{
    public interface IReadDbContext<TIEntity>
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class, TIEntity;
    }
}
