using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.User;
using Microsoft.AspNetCore.Authorization;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    [Authorize]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetUserViewModel>> GetAll()
        {
            return await _userService.GetAll();
        }
    }
}

//protected string userEmail => User?.Identity?.IsAuthenticated == true ?
//            User.Identity.Name : "";