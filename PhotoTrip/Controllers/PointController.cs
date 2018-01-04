using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<PointDto> GetAllPoints()
        {
            return _pointService.GetAll();
        }

        [HttpGet("{id}")]
        public PointDto GetPoint(int id)
        {
            var result =  _pointService.GetPoint(id);
            return result;
        }

        [HttpPost]
        public void AddPoint([FromBody]CreatePointViewModel point)
        {
            _pointService.AddPoint(point);
        }

        [HttpPut("{id}")]
        public void UpdatePoint(int id,[FromBody] UpdatePointViewModel point)
        {
            _pointService.UpdatePoint(id, point);
        }

        [HttpDelete("{id}")]
        public void DeletePoint(int id)
        {
            _pointService.DeletePoint(id);
        }

        [HttpGet("nearest")]
        public IEnumerable<PointDto> GetNearest(float latitude, float longitude)
        {
            return _pointService.GetPoint(latitude, longitude);
        }

    }
}