using PhotoTrip.Core.Domain;
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
        Event AddEvent(CreateEventViewModel @event);
        Event UpdateEvent(int id, UpdateEventViewModel @event);
    }
}
