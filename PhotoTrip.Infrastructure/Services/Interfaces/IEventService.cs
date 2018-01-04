using PhotoTrip.Infrastructure.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IEventService : IService
    {
        EventDto GetEvent(int id);
        IEnumerable<EventDto> GetAllEvents();
        void DeleteEvent(int id);
        void AddEvent(CreateEventViewModel @event);
        void UpdateEvent(int id, UpdateEventViewModel @event);
    }
}
