using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoTrip.Core.Domain
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string PhotoName { get; set; }
    }
}
