using Microsoft.AspNetCore.Mvc;
using PortifolioCarros.API.DTOs;
using PortifolioCarros.API.Persistence.SqlServer.Repositories;

namespace PortifolioCarros.API.Controllers
{
    [Route("auto/")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository;

        public CarController(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [Route("cars")]
        [HttpGet]
        public ActionResult<IEnumerable<GetCarsDto>> GetCars()
        {
            return Ok(_carRepository.List());
        }

        [Route("cars/{id}")]
        [HttpGet]
        public ActionResult<CarDetailDto> Get(int id)
        {
            var car = _carRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [Route("cars")]
        [HttpPost]
        public ActionResult<CarDetailDto> Create(CreateCarDto model)
        {
            var response = _carRepository.Create(model);
            return Ok(response);
        }

    }
}
