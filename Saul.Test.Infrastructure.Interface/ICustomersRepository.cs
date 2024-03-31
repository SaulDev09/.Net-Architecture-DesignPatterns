using Saul.Test.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Infrastructure.Interface
{
    public interface ICustomersRepository
    {
        Task<bool> Insert(Customers customers);
        Task<bool> Update(Customers customers);
        Task<bool> Delete(Customers customers);
        Task<Customers> Get(string customerId);
        Task<IEnumerable<Customers>> GetAll();
    }
}
