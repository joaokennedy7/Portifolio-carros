using AutoMapper;

namespace PortifolioCarros.API.Mappers.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Entities.Car, DTOs.GetCarsDto>()
                .ForPath(dest => dest.Photo, m => m.MapFrom(src => src.Pictures.FirstOrDefault().Url));

            CreateMap<Entities.Car, DTOs.CarDetailDto>();

            CreateMap<DTOs.CreateOrUpdateCarDto, Entities.Car>();
        }
    }
}
