using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoTrip.Core.Domain
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Point { get; set; }
        public User User { get; set; }
        public string PhotoName { get; set; }
    }
}
