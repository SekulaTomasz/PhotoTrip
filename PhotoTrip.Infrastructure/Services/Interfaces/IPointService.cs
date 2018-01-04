using PhotoTrip.Infrastructure.ViewModels.Point;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services.Interfaces
{
    public interface IPointService : IService
    {
        PointDto GetPoint(int id);
        void AddPoint(CreatePointViewModel point);
        void UpdatePoint(int id, UpdatePointViewModel point);
        void DeletePoint(int id);
        IEnumerable<PointDto> GetAll();
        IEnumerable<PointDto> GetPoint(float latitude, float longitude);
    }
}
