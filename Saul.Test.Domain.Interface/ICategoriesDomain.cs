using Saul.Test.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Domain.Interface
{
    public interface ICategoriesDomain
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}
