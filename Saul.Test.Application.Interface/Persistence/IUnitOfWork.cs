using System;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
        ICategoriesRepository Categories { get; }
    }
}
