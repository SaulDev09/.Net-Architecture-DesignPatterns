using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.UseCases
{
    public interface ICustomersApplication
    {
        Task<Response<bool>> Insert(CustomerDto customersDto);
        Task<Response<bool>> Update(CustomerDto customersDto);
        Task<Response<bool>> Delete(string customerId);
        Task<Response<CustomerDto>> Get(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAll();
        Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPagination(int pageNumber, int pageSize);
    }
}
