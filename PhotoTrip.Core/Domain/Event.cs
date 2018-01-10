using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoTrip.Core.Domain
{
    public class Event : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Photo Photo { get; set; }
        public Point Point { get; set; }
    }
}
