using Saul.Test.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}
