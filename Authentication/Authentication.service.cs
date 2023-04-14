using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using central_fish_agency_dotnet.Common.interfaces;

namespace central_fish_agency_dotnet.Common.Middleware
{
    public class AuthenticationService : IAuthentication
    {
        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}