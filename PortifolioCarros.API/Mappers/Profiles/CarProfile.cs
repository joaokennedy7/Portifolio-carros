using AutoMapper;

namespace PortifolioCarros.API.Mappers.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Entities.Car, DTOs.GetCarsDto>()
                .ForMember(x => x.UrlPhoto, a => a.Ignore());

            CreateMap<Entities.Car, DTOs.CarDetailDto>();

            CreateMap<DTOs.CreateCarDto, Entities.Car>();
        }
    }
}
