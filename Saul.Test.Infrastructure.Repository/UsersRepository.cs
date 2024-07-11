using Dapper;
using Saul.Test.Domain.Entity;
using Saul.Test.Infrastructure.Interface;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Infrastructure.Repository
{
    public class UsersRepository: IUsersRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string userName, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("username", userName);
                parameters.Add("password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return user;
            }

        }
    }
}
