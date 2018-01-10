using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Database;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ApiBaseController : Controller
    {
        protected string UserEmail => User?.Identity?.IsAuthenticated == true ?
            User.Identity.Name : "";
    }
}