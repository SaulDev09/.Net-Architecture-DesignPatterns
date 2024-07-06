using Saul.Test.Application.DTO;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface
{
    public interface ICustomersApplication
    {
        Task<Response<bool>> Insert(CustomersDto customersDto);
        Task<Response<bool>> Update(CustomersDto customersDto);
        Task<Response<bool>> Delete(string customerId);
        Task<Response<CustomersDto>> Get(string customerId);
        Task<Response<IEnumerable<CustomersDto>>> GetAll();
    }
}
