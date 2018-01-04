using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Event;

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
        public EventDto GetEvent(int id)
        {
            return _eventService.GetEvent(id);
        }

        [HttpGet]
        public IEnumerable<EventDto> GetAllEvents()
        {
            return _eventService.GetAllEvents();
        }

        [HttpPost]
        public void AddEvent([FromBody]CreateEventViewModel @event)
        {
            _eventService.AddEvent(@event);
        }

        [HttpPut("{id}")]
        public void UpdateEvent(int id, [FromBody] UpdateEventViewModel @event)
        {
            _eventService.UpdateEvent(id, @event);
        }

        [HttpDelete("{id}")]
        public void DeleteEvent(int id)
        {
            _eventService.DeleteEvent(id);
        }

    }
}