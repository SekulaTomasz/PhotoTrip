using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.ViewModels.Point;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IPointService : IService
    {
        Task<PointDto> GetPoint(int id);
        Task<Point> AddPoint(CreatePointViewModel point);
        Task<Point> UpdatePoint(int id, UpdatePointViewModel point);
        Task DeletePoint(int id);
        Task<IEnumerable<PointDto>> GetAll();
        Task<IEnumerable<PointDto>> GetPoint(float latitude, float longitude);
    }
}
