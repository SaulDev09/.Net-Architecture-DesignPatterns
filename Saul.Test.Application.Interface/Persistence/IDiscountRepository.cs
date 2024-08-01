using Saul.Test.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<Discount> Get(int id, CancellationToken cancellationToken);
        Task<List<Discount>> GetAll(CancellationToken cancellationToken);
    }
}
