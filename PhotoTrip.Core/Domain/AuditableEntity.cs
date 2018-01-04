using PhotoTrip.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Core.Domain
{
    public class AuditableEntity : IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
