using System;
using System.Collections.Generic;
using System.Text;
using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.Point;

namespace PhotoTrip.Infrastructure.ViewModels.Event
{
    public class UpdateEventViewModel
    {
        public string Name { get; set; }
        public string PhotoName { get; set; }
        public PointIdentity Point { get; set; }
    }
}
