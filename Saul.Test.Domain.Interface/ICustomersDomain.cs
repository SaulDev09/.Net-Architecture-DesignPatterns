using Saul.Test.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Domain.Interface
{
    public interface ICustomersDomain
    {
        Task<bool> Insert(Customers customers);
        Task<bool> Update(Customers customers);
        Task<bool> Delete(string customerId);
        Task<Customers> Get(string customerId);
        Task<IEnumerable<Customers>> GetAll();
        Task<IEnumerable<Customers>> GetAllWithPagination(int pageNumber, int pageSize);
        Task<int> Count();
    }
}
