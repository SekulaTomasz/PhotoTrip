using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Core.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
