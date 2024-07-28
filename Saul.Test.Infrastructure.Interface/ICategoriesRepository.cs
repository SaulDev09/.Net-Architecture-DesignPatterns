using Saul.Test.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Infrastructure.Interface
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}
