using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels;
using PhotoTrip.Infrastructure.ViewModels.User;
using System.Threading.Tasks;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    public class AccountController : ApiBaseController
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserService _userService;

        public AccountController(IJwtHandler jwtHandler, IUserService userService)
        {
            _jwtHandler = jwtHandler;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public async Task<JwtDto> GetToken(string email)
        {
            if (!await _userService.CheckIsExist(email))
            {
                return null;
            }
            var token = _jwtHandler.CreateToken(email, "admin");
            return token;
        }
    }
}