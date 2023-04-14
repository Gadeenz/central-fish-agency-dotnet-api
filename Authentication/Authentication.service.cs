using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace central_fish_agency_dotnet.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        private readonly DataContext _context;
        public AuthenticationService(DataContext context)
        {
            _context = context;

        }



        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (user is null)
            {
                response.Success = false;
                response.Message = $"user with this emai : {email} not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "wrong password.";
            }
            else
            {
                response.Data = user.Id.ToString();
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(user.Email))
            {
                response.Success = false;
                response.Message = $"User with email '{user.Email}' already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.Id;
            response.Message = $"user with user name : '{user.Username}' email : '{user.Email}' created successfully.";
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}