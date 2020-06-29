using System;

namespace PhonesBook.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        void Commit();
    }
}
