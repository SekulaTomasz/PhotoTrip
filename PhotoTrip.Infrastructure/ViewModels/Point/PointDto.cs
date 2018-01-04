using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.ViewModels.Point
{
    public class PointDto
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public IEnumerable<EventDto> Events { get; set; }
    }
}
