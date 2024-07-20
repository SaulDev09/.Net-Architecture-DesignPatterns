using Saul.Test.Domain.Entity;

namespace Saul.Test.Infrastructure.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string userName, string password);
    }
}
