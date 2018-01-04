using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.User;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<GetUserViewModel> GetAll()
        {
            return _userService.GetAll();
        }

    }
}