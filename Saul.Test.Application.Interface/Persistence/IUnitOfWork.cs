using System;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
        ICategoriesRepository Categories { get; }
        IDiscountRepository Discounts { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
