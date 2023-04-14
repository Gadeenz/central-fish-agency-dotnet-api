using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace central_fish_agency_dotnet.Users.Dtos
{
    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}