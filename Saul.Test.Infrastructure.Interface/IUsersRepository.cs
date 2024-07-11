using Saul.Test.Domain.Entity;

namespace Saul.Test.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string userName, string password);
    }
}
