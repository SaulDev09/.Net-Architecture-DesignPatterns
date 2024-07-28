using Saul.Test.Domain.Entity;
using Saul.Test.Domain.Interface;
using Saul.Test.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Domain.Core
{
    public class CategoriesDomain : ICategoriesDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _unitOfWork.Categories.GetAll();
        }
    }
}
