using AutoMapper;
using PortifolioCarros.API.DTOs;
using PortifolioCarros.API.Validations;

namespace PortifolioCarros.API.Persistence.SqlServer.Repositories
{
    public class CarRepository
    {
        private readonly PortifolioContext _context;
        private readonly IMapper _mapper;

        public CarRepository(PortifolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<GetCarsDto> List()
        {
            var cars = _context.Car.ToList();
            return _mapper.Map<IEnumerable<GetCarsDto>>(cars);
        }

        public CarDetailDto Get(int id)
        {
            var detail = _context.Car.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<CarDetailDto>(detail);
        }

        public CarDetailDto Create(CreateCarDto model)
        {
            var entity = _mapper.Map<Entities.Car>(model);

            foreach (string url in model.Photos)
                entity.Pictures.Add(new Entities.Picture() { Url = url });

            var carCreated = _context.Car.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<CarDetailDto>(carCreated.Entity);
        }
    }
}
