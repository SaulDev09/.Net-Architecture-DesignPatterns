using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetAll();
    }
}
