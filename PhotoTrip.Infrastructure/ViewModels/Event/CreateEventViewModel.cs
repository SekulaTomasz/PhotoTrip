using PhotoTrip.Infrastructure.ViewModels.Point;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.ViewModels.Event
{
    public class CreateEventViewModel
    {
        public string Name { get; set; }
        public string PhotoName { get; set; }
        public PointIdentity Point { get; set; }
    }
}
