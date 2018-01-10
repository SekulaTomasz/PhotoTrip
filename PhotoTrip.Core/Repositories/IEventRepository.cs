using PhotoTrip.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Core.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        string UserEmail { get; set; }
    }
}
