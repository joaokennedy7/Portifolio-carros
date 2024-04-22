using ErrorOr;
using PortifolioCarros.API.DTOs;

namespace PortifolioCarros.API.Persistence.SqlServer.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<GetCarsDto> List();
        CarDetailDto Get(int id);
        ErrorOr<CarDetailDto> Create(CreateOrUpdateCarDto model);
        ErrorOr<CarDetailDto> Update(int id, CreateOrUpdateCarDto model);
        ErrorOr<object> Delete(int id);
    }
}
