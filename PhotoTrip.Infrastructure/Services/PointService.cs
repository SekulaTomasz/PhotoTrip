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

        public async Task<Point> AddPoint(CreatePointViewModel point)
        {
            var newPoint = Mapper.Map<CreatePointViewModel, Point>(point);
            return await _pointRepository.Post(newPoint);
        }

        public async Task<PointDto> GetPoint(int id)
        {
            var result = await _pointRepository.Get(id);
            return Mapper.Map<Point, PointDto>(result);
        }

        public async Task<Point> UpdatePoint(int id, UpdatePointViewModel point)
        {
            var updatedPoint = Mapper.Map<UpdatePointViewModel, Point>(point);
            updatedPoint.Id = id;
            return await _pointRepository.Put(updatedPoint);
        }

        public async Task DeletePoint(int id)
        {
            await _pointRepository.Delete(id);
        }

        public async Task<IEnumerable<PointDto>> GetAll()
        {
            var result = await _pointRepository.GetList();
            return Mapper.Map<IEnumerable<Point>, IEnumerable<PointDto>>(result);
        }

        public async Task<IEnumerable<PointDto>> GetPoint(float latitude, float longitude)
        {
            var result = await _pointRepository.GetList();
            if (result == null)
                return null;
            var closest = result.OrderBy(x => Math.Abs(x.Latitude - latitude)).ThenBy(x => Math.Abs(x.Longitude - longitude)).Take(10);
            return Mapper.Map<IEnumerable<Point>, IEnumerable<PointDto>>(closest);
        }
    }
}
