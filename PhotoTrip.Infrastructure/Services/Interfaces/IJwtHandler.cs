using PhotoTrip.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email,string role);
    }
}
