using Dapper;
using Saul.Test.Domain.Entity;
using Saul.Test.Infrastructure.Data;
using Saul.Test.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;

        public UsersRepository(DapperContext context)
        {
            _context = context;
        }

        public Users Authenticate(string userName, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("username", userName);
                parameters.Add("password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return user;
            }

        }

        public Task<bool> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Users> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Insert(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new System.NotImplementedException();
        }

    }
}
