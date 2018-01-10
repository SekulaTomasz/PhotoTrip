using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Event;
using PhotoTrip.Core.Domain;
using Microsoft.AspNetCore.Authorization;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    [Authorize]
    public class EventController : ApiBaseController
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
            _eventService.UserEmail = UserEmail;
            return await _eventService.AddEvent(@event);
        }

        [HttpPut("{id}")]
        public async Task<Event> UpdateEvent(int id,[FromBody] UpdateEventViewModel @event)
        {
            _eventService.UserEmail = UserEmail;
            return await _eventService.UpdateEvent(id, @event);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEvent(int id)
        {
            await _eventService.DeleteEvent(id);
        }

    }
}