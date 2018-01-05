using System.Collections.Generic;
using AutoMapper;
using PhotoTrip.Core.Domain;
using PhotoTrip.Core.Repositories;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Event;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;


        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> AddEvent(CreateEventViewModel @event)
        {
            var newEvent = Mapper.Map<CreateEventViewModel, Event>(@event);
            return await _eventRepository.Post(newEvent);
        }

        public async Task DeleteEvent(int id)
        {
            await _eventRepository.Delete(id);
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents()
        {
            var result = await _eventRepository.GetList();
            return Mapper.Map<IEnumerable<Event>, IEnumerable<EventDto>>(result);
        }

        public async Task<EventDto> GetEvent(int id)
        {
            var result = await _eventRepository.Get(id);
            return Mapper.Map<Event, EventDto>(result);
        }

        public async Task<Event> UpdateEvent(int id, UpdateEventViewModel @event)
        {
            var updatedEvent = Mapper.Map<UpdateEventViewModel, Event>(@event);
            updatedEvent.Id = id;
            return await _eventRepository.Put(updatedEvent);
        }
    }
}
