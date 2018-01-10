using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels;
using PhotoTrip.Infrastructure.ViewModels.User;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    public class AccountController : ApiBaseController
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public JwtDto GetToken(string email)
        {
            var token = _jwtHandler.CreateToken(email, "admin");
            return token;
        }
    }
}