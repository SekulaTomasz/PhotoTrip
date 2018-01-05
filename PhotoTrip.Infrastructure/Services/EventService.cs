using System.Collections.Generic;
using AutoMapper;
using PhotoTrip.Core.Domain;
using PhotoTrip.Core.Repositories;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Event;

namespace PhotoTrip.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;


        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event AddEvent(CreateEventViewModel @event)
        {
            var newEvent = Mapper.Map<CreateEventViewModel, Event>(@event);
            return _eventRepository.Post(newEvent);
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
        }

        public IEnumerable<EventDto> GetAllEvents()
        {
            var result = _eventRepository.GetList();
            return Mapper.Map<IEnumerable<Event>, IEnumerable<EventDto>>(result);
        }

        public EventDto GetEvent(int id)
        {
            var result = _eventRepository.Get(id);
            return Mapper.Map<Event, EventDto>(result);
        }

        public Event UpdateEvent(int id, UpdateEventViewModel @event)
        {
            var updatedEvent = Mapper.Map<UpdateEventViewModel, Event>(@event);
            updatedEvent.Id = id;
            return _eventRepository.Put(updatedEvent);
        }
    }
}
