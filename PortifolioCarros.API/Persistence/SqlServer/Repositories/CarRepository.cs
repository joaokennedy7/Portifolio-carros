using AutoMapper;
using PortifolioCarros.API.DTOs;
using PortifolioCarros.API.Validations;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace PortifolioCarros.API.Persistence.SqlServer.Repositories
{
    public class CarRepository : ICarRepository
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
            var cars = _context.Car.AsNoTracking().Include(x => x.Pictures).ToList();
            return _mapper.Map<IEnumerable<GetCarsDto>>(cars);
        }

        public CarDetailDto Get(int id)
        {
            var detail = _context.Car.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<CarDetailDto>(detail);
        }

        public ErrorOr<CarDetailDto> Create(CreateOrUpdateCarDto model)
        {
            var entity = _mapper.Map<Entities.Car>(model);

            foreach (string url in model.Photos)
                entity.Pictures.Add(new Entities.Picture() { Url = url });

            List<Error> errors = new();
            var validation = new CarValidation().Validate(entity);

            foreach(var error in validation.Errors)
                errors.Add(Error.Validation(error.ErrorCode, error.ErrorMessage));

            if (!validation.IsValid)
                return errors;

            var carCreated = _context.Car.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<CarDetailDto>(carCreated.Entity);
        }

        public ErrorOr<CarDetailDto> Update(int id, CreateOrUpdateCarDto model)
        {
            var entity = _context.Car.AsNoTracking().Include(x => x.Pictures).FirstOrDefault(x => x.Id.Equals(id));

            if (entity is null)
                return Error.NotFound(description: "O carro não foi encontrado");

            foreach (string url in model.Photos)
                entity.Pictures.Add(new Entities.Picture() { Url = url });

            entity = _mapper.Map(model, entity);
            entity.AtualizadoEm = DateTime.Now;

            List<Error> errors = new();
            var validation = new CarValidation().Validate(entity);

            foreach (var error in validation.Errors)
                errors.Add(Error.Validation(error.ErrorCode, error.ErrorMessage));

            if (!validation.IsValid)
                return errors;

            var entityToUpdate = _context.Car.Update(entity);
            _context.SaveChanges();

            return _mapper.Map<CarDetailDto>(entityToUpdate.Entity);
        }

        public ErrorOr<object> Delete(int id)
        {
            var entity = _context.Car.Find(id);

            if (entity is null)           
               return Error.NotFound(description: "O carro não foi encontrado!");
             
            _context.Car.Remove(entity);
            _context.SaveChanges();

            return new
            {
                Message = "O carro foi removido do nosso sistema"
            };
        }
    }
}
