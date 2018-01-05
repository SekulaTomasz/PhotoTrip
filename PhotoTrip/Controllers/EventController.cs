using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Event;
using PhotoTrip.Core.Domain;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<EventDto> GetEvent(int id)
        {
            return await _eventService.GetEvent(id);
        }

        [HttpGet]
        public async Task<IEnumerable<EventDto>> GetAllEvents()
        {
            return await _eventService.GetAllEvents();
        }

        [HttpPost]
        public async Task<Event> AddEvent([FromBody]CreateEventViewModel @event)
        {
            return await _eventService.AddEvent(@event);
        }

        [HttpPut("{id}")]
        public async Task<Event> UpdateEvent(int id,[FromBody] UpdateEventViewModel @event)
        {
            return await _eventService.UpdateEvent(id, @event);
        }

        [HttpDelete("{id}")]
        public void DeleteEvent(int id)
        {
            _eventService.DeleteEvent(id);
        }

    }
}