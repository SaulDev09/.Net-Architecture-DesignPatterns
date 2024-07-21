using Saul.Test.Domain.Entity;
using Saul.Test.Domain.Interface;
using Saul.Test.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saul.Test.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Insert(Customers customers)
        {
            return await _unitOfWork.Customers.Insert(customers);
        }

        public async Task<bool> Update(Customers customers)
        {
            return await _unitOfWork.Customers.Update(customers);
        }

        public async Task<bool> Delete(string customerId)
        {
            return await _unitOfWork.Customers.Delete(customerId);
        }

        public async Task<Customers> Get(string customerId)
        {
            return await _unitOfWork.Customers.Get(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAll()
        {
            return await _unitOfWork.Customers.GetAll();
        }

        public async Task<IEnumerable<Customers>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
        }

        public async Task<int> Count()
        {
            return await (_unitOfWork.Customers.Count());
        }
    }
}
