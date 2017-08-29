using System.Data.Entity;

namespace WebDev.Data.Contracts
{
    public interface IWebDevEntities
    {
        IDbSet<TEntity> DbSet<TEntity>()
         where TEntity : class;

        int SaveChanges();

        void SetAdded<TEntry>(TEntry entity)
            where TEntry : class;

        void SetDeleted<TEntry>(TEntry entity)
            where TEntry : class;

        void SetUpdated<TEntry>(TEntry entity)
            where TEntry : class;
    }
}