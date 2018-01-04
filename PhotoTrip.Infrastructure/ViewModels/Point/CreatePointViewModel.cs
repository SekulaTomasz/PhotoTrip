using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Infrastructure.ViewModels.Point
{
    public class CreatePointViewModel
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
