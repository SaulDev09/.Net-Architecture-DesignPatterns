using System;

namespace Saul.Test.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
