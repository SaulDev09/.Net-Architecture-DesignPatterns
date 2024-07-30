using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.UseCases
{
    public interface ICategoriesApplication
    {
        Task<Response<IEnumerable<CategoriesDto>>> GetAll();
    }
}
