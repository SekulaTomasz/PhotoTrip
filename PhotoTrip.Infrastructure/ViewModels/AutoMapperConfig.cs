using AutoMapper;
using PhotoTrip.Infrastructure.ViewModels.Event;
using PhotoTrip.Infrastructure.ViewModels.Photo;
using PhotoTrip.Infrastructure.ViewModels.Point;
using PhotoTrip.Infrastructure.ViewModels.User;

namespace PhotoTrip.Infrastructure.ViewModels
{
    public class AutoMapperConfig : Profile
    { 
        public AutoMapperConfig()
        {
            CreateMap<PhotoTrip.Core.Domain.User, GetUserViewModel>();
            CreateMap<PhotoTrip.Core.Domain.Point, PointDto>();
            CreateMap<PhotoTrip.Core.Domain.Event, EventDto>();
            CreateMap<CreatePointViewModel, PhotoTrip.Core.Domain.Point>();
            CreateMap<UpdatePointViewModel, PhotoTrip.Core.Domain.Point>();
            CreateMap<UpdateEventViewModel, PhotoTrip.Core.Domain.Event>();
            CreateMap<CreateEventViewModel, PhotoTrip.Core.Domain.Event>();
            CreateMap<PointIdentity, PhotoTrip.Core.Domain.Point>();
            CreateMap<PhotoTrip.Core.Domain.Point, PointIdentity>();
            CreateMap<PhotoTrip.Core.Domain.Photo, PhotoDto>();
            CreateMap<PhotoDto, PhotoTrip.Core.Domain.Photo>();
        }
    }
}
