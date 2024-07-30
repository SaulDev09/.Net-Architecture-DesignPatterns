using Saul.Test.Domain.Entity;

namespace Saul.Test.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string userName, string password);
    }
}
