using System;
using WebDev.Data.Contracts;

namespace WebDev.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IWebDevEntities dbContext;

        public UnitOfWork(IWebDevEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

            this.dbContext = context;
        }

        public void Dispose()
        {
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}