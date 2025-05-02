using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }

        public IUsersRepository Users { get; }

        public ICategoriesRepository Categories { get; }

        public IDiscountRepository Discounts { get; }
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories, IDiscountRepository discount, ApplicationDbContext applicationDbContext)
        {
            Customers = customers;
            Users = users;
            Categories = categories;
            Discounts = discount;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
