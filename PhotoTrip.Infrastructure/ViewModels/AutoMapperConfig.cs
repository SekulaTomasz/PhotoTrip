using AutoMapper;
using PhotoTrip.Infrastructure.ViewModels.User;

namespace PhotoTrip.Infrastructure.ViewModels
{
    public class AutoMapperConfig : Profile
    { 
        public AutoMapperConfig()
        {
            CreateMap<PhotoTrip.Core.Domain.User, GetUserViewModel>();
        }
    }
}
