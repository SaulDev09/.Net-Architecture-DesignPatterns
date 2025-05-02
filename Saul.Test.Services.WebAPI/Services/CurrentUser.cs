using Saul.Test.Application.Interface.Presentation;
using Saul.Test.Application.UseCases.Common.Constants;
using System.Security.Claims;

namespace Saul.Test.Services.WebAPI.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("userid") ?? GlobalConstant.DefaultUserId;

        public string UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue("username") ?? GlobalConstant.DefaultUserName;
    }
}
