using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace central_fish_agency_dotnet.Users.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
    }
}