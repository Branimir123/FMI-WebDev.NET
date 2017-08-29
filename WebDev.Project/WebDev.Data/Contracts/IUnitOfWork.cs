using System;

namespace WebDev.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}