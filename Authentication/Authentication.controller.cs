using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using central_fish_agency_dotnet.Users.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace central_fish_agency_dotnet.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authRepo;

        public AuthenticationController(IAuthentication authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {

            var response = await _authRepo.Register(
                new User { Username = request.Username, Email = request.Email }, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}