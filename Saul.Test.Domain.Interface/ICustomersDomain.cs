using System.Threading.Tasks;
using Saul.Test.Domain.Entity;

namespace Saul.Test.Domain.Interface
{
    public interface ICustomersDomain
    {
        Task<bool> Insert(Customers customers);
    }
}
