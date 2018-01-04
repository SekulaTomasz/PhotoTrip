using PhotoTrip.Infrastructure.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IUserService : IService
    {
        IEnumerable<GetUserViewModel> GetAll();
    }
}
