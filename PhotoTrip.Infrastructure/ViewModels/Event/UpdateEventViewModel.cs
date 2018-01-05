using System;
using System.Collections.Generic;
using System.Text;
using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.Point;
using PhotoTrip.Infrastructure.ViewModels.Photo;

namespace PhotoTrip.Infrastructure.ViewModels.Event
{
    public class UpdateEventViewModel
    {
        public string Name { get; set; }
        public PhotoDto Photo { get; set; }
        public PointIdentity Point { get; set; }
    }
}
