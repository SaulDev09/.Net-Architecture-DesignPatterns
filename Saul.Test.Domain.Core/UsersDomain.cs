using Saul.Test.Domain.Entity;
using Saul.Test.Domain.Interface;
using Saul.Test.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saul.Test.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string userName, string password)
        {
            return _unitOfWork.Users.Authenticate(userName, password);
        }
    }
}
