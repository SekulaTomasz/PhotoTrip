using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IEventService : IService
    {
        string UserEmail { get; set; }
        Task<EventDto> GetEvent(int id);
        Task<IEnumerable<EventDto>> GetAllEvents();
        Task DeleteEvent(int id);
        Task<Event> AddEvent(CreateEventViewModel @event);
        Task<Event> UpdateEvent(int id, UpdateEventViewModel @event);
    }
}
