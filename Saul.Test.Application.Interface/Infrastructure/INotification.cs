using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.Interface.Infrastructure
{
    public interface INotification
    {
        Task<bool> SendMail(string subject, string body, CancellationToken cancellationToken = new());
    }
}
