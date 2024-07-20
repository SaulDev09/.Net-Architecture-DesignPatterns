using Dapper;
using Saul.Test.Domain.Entity;
using Saul.Test.Infrastructure.Data;
using Saul.Test.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Saul.Test.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(Customers customers)
        {
            using (var connection = _context.CreateConnection())
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
            using (var connection = _context.CreateConnection())
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
            using (var connection = _context.CreateConnection())
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
            using (var connection = _context.CreateConnection())
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
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var result = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


    }
}
