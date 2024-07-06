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
        private readonly ICustomersRepository _customersRepository;
        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public async Task<bool> Insert(Customers customers)
        {
            return await _customersRepository.Insert(customers);
        }

        public async Task<bool> Update(Customers customers)
        {
            return await _customersRepository.Update(customers);
        }

        public async Task<bool> Delete(string customerId)
        {
            return await _customersRepository.Delete(customerId);
        }

        public async Task<Customers> Get(string customerId)
        {
            return await _customersRepository.Get(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAll()
        {
            return await _customersRepository.GetAll();
        }
    }
}
