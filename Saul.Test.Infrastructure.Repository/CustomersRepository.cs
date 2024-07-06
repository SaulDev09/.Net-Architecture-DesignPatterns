using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Saul.Test.Domain.Entity;
using Saul.Test.Infrastructure.Interface;
using Saul.Test.Transversal.Common;
using Dapper;
using System.Data;

namespace Saul.Test.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> Insert(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", customers.CustomerId);
                parameters.Add("@CompanyName", customers.CompanyName);
                parameters.Add("@ContactName", customers.ContactName);
                parameters.Add("@ContactTitle", customers.ContactTitle);
                parameters.Add("@Address", customers.Address);
                parameters.Add("@City", customers.City);
                parameters.Add("@Region", customers.Region);
                parameters.Add("@PostalCode", customers.PostalCode);
                parameters.Add("@Country", customers.Country);
                parameters.Add("@Phone", customers.Phone);
                parameters.Add("@Fax", customers.Fax);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", customers.CustomerId);
                parameters.Add("@CompanyName", customers.CompanyName);
                parameters.Add("@ContactName", customers.ContactName);
                parameters.Add("@ContactTitle", customers.ContactTitle);
                parameters.Add("@Address", customers.Address);
                parameters.Add("@City", customers.City);
                parameters.Add("@Region", customers.Region);
                parameters.Add("@PostalCode", customers.PostalCode);
                parameters.Add("@Country", customers.Country);
                parameters.Add("@Phone", customers.Phone);
                parameters.Add("@Fax", customers.Fax);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", customerId);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", customerId);

                var result = await connection.QuerySingleAsync<Customers>(query, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Customers>> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var result = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


    }
}
