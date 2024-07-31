using Dapper;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Domain.Entity;
using Saul.Test.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;

        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public User Authenticate(string userName, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("username", userName);
                parameters.Add("password", password);

                var user = connection.QuerySingle<User>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return user;
            }

        }

        public Task<bool> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new System.NotImplementedException();
        }

    }
}
