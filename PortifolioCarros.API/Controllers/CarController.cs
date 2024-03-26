using Microsoft.AspNetCore.Mvc;
using PortifolioCarros.API.DTOs;

namespace PortifolioCarros.API.Controllers
{

    [Route("auto/")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly List<GetCarsDto> cars = new List<GetCarsDto>
        {
            new GetCarsDto (1, "Nivus", "Volksvagem", 2022, "url1", 100000),
            new GetCarsDto (2, "Onix", "Chevrolet", 2021, "url2", 75000),
            new GetCarsDto (3, "GLE 200", "Mercedes", 2017, "url3", 175000)
        };

        [Route("cars")]
        [HttpGet]
        public IActionResult GetCars()
        {
            var listagemCarros = cars;

            return Ok(listagemCarros);
        }

        
    }
}
