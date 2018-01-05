using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.Photo;
using PhotoTrip.Infrastructure.ViewModels.Point;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.ViewModels.Event
{
    public class CreateEventViewModel
    {
        public string Name { get; set; }
        public PhotoDto Photo { get; set; }
        public PointIdentity Point { get; set; }
    }
}
