using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<IEnumerable<GetUserViewModel>> GetAll();
        Task<GetUserViewModel> GetByEmail(string email);
        Task<bool> CheckIsExist(string email);
    }
}
