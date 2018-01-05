using PhotoTrip.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.ViewModels.Event
{
    public class EventDto
    {
        public string Name { get; set; }
        public PhotoTrip.Core.Domain.Photo Photo { get; set; }
    }
}
