using PhotoTrip.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PhotoTrip.Infrastructure.ViewModels.User;
using System.Threading.Tasks;
using PhotoTrip.Core.Repositories;
using AutoMapper;
using PhotoTrip.Core.Domain;

namespace PhotoTrip.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckIsExist(string email)
        {
            return await _userRepository.CheckIsExist(email);
        }

        public async Task<IEnumerable<GetUserViewModel>> GetAll()
        {
            var result = await _userRepository.GetList();
            return Mapper.Map<IEnumerable<User>, IEnumerable<GetUserViewModel>>(result);
        }

        public async Task<GetUserViewModel> GetByEmail(string email)
        {
            var result = await _userRepository.GetByEmail(email);
            return Mapper.Map<User, GetUserViewModel>(result);
        }
    }
}
