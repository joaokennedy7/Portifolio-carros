using Microsoft.AspNetCore.Mvc;
using PortifolioCarros.API.DTOs;
using PortifolioCarros.API.Persistence.SqlServer.Repositories;

namespace PortifolioCarros.API.Controllers
{
    [Route("auto/")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
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
        public ActionResult<CarDetailDto> Create(CreateOrUpdateCarDto model)
        {
            var response = _carRepository.Create(model);

            if (response.IsError)
                return BadRequest(response.Errors);

            return Ok(response.Value);
        }

        [Route("cars/{id}")]
        [HttpPut]
        public ActionResult<CarDetailDto> Update(int id, CreateOrUpdateCarDto model)
        {
            var response = _carRepository.Update(id, model);

            if (response.IsError)
                return NotFound(response.Errors);

            return Ok(response.Value);
        }

        [Route("cars/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var response = _carRepository.Delete(id);

            if (response.IsError)
                return NotFound(response.Errors);

            return Ok(response.Value);
        }
    }
}
