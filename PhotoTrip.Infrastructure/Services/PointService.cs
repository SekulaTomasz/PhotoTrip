using PhotoTrip.Core.Repositories;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Point;
using System.Threading.Tasks;
using PhotoTrip.Core.Domain;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PhotoTrip.Infrastructure.Services
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;


        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public void AddPoint(CreatePointViewModel point)
        {
            var newPoint = Mapper.Map<CreatePointViewModel, Point>(point);
            _pointRepository.Post(newPoint);
        }

        public PointDto GetPoint(int id)
        {
            var result = _pointRepository.Get(id);
            return Mapper.Map<Point, PointDto>(result);
        }

        public void UpdatePoint(int id, UpdatePointViewModel point)
        {
            var updatedPoint = Mapper.Map<UpdatePointViewModel, Point>(point);
            updatedPoint.Id = id;
            _pointRepository.Put(updatedPoint);
        }

        public void DeletePoint(int id)
        {
            _pointRepository.Delete(id);
        }

        public IEnumerable<PointDto> GetAll()
        {
            var result = _pointRepository.GetList();
            return Mapper.Map<IEnumerable<Point>, IEnumerable<PointDto>>(result);
        }

        public IEnumerable<PointDto> GetPoint(float latitude, float longitude)
        {
            var result = _pointRepository.GetList().ToList();
            if (result == null)
                return null;
            var closest = result.OrderBy(x => Math.Abs(x.Latitude - latitude)).ThenBy(x => Math.Abs(x.Longitude - longitude)).Take(10);
            return Mapper.Map<IEnumerable<Point>, IEnumerable<PointDto>>(closest);
        }
    }
}
