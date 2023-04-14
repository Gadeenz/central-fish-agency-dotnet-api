using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using central_fish_agency_dotnet.Common.interfaces;

namespace central_fish_agency_dotnet.Common.Middleware
{
    public class AuthenticationService : IAuthentication
    {
        private readonly DataContext _context;
        public AuthenticationService(DataContext context)
        {
            _context = context;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(user.UserEmail))
            {
                response.Success = false;
                response.Message = $"User with email '{user.UserEmail}' already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string userEmail)
        {
            if (await _context.Users.AnyAsync(u => u.UserEmail.ToLower() == userEmail.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}