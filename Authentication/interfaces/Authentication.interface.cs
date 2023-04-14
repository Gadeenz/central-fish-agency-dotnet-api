using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace central_fish_agency_dotnet.Authentication.interfaces
{
    public interface IAuthentication
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}