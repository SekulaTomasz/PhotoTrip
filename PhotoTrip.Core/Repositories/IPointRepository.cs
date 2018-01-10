using PhotoTrip.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoTrip.Core.Repositories
{
    public interface IPointRepository : IRepository<Point>
    {
        string UserEmail { get; set; }
    }
}
