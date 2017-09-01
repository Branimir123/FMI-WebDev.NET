using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using WebDev.Data.Contracts;
using WebDev.Models;

namespace WebDev.Data
{
    public class WebDevEntities : DbContext, IWebDevEntities
    {
        public WebDevEntities()
            : base("WordGameDb")
        {
            this.Configuration.AutoDetectChangesEnabled = true;

            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public static WebDevEntities Create()
        {
            return new WebDevEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        public IDbSet<Word> Words { get; set; }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public void SetAdded<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void SetDeleted<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void SetUpdated<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}