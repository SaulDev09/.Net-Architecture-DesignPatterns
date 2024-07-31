using Dapper;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Domain.Entity;
using Saul.Test.Persistence.Contexts;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Saul.Test.Persistence.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(Customer customers)
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

        public async Task<bool> Update(Customer customers)
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

        public async Task<Customer> Get(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", customerId);

                var result = await connection.QuerySingleAsync<Customer>(query, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var result = await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersListWithPagination";
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", pageNumber);
                parameters.Add("@PageSize", pageSize);
                var result = await connection.QueryAsync<Customer>(query, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Count()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "select count(1) from Customers";
                var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
                return count;

            }
        }
    }
}
