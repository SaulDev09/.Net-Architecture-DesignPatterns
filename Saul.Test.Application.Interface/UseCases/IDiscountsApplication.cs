using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.UseCases
{
    public interface IDiscountsApplication
    {
        Task<Response<bool>> Insert(DiscountDto discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default);
        Task<Response<DiscountDto>> Get(int id, CancellationToken cancellationToken = default);
        Task<Response<List<DiscountDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPagination(int pageNumber, int pageSize);
    }
}
