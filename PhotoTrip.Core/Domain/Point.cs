using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoTrip.Core.Domain
{
    public class Point
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; } //szerokosc
        public float Longitude { get; set; } //dlugosc
        public IEnumerable<Event> Events { get; set; }
        public User User { get; set; }
    }
}
