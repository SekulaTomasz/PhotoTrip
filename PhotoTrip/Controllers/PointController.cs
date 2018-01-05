using Microsoft.AspNetCore.Mvc;
using PhotoTrip.Core.Domain;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.ViewModels.Point;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoTrip.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PointController : Controller
    {
        private readonly IPointService _pointService;

        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<IEnumerable<PointDto>> GetAllPoints()
        {
            return await _pointService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<PointDto> GetPoint(int id)
        {
            var result = await _pointService.GetPoint(id);
            return result;
        }

        [HttpPost]
        public void AddPoint([FromBody]CreatePointViewModel point)
        {
            _pointService.AddPoint(point);
        }

        [HttpPut("{id}")]
        public async Task<Point> UpdatePoint(int id,[FromBody]UpdatePointViewModel point)
        {
            return await _pointService.UpdatePoint(id, point);
        }

        [HttpDelete("{id}")]
        public void DeletePoint(int id)
        {
            _pointService.DeletePoint(id);
        }

        [HttpGet("nearest")]
        public async Task<IEnumerable<PointDto>> GetNearest(float latitude, float longitude)
        {
            return await _pointService.GetPoint(latitude, longitude);
        }

    }
}