using AutoMapper;

namespace PortifolioCarros.API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
                cfg.AddMaps(new[] {
                    "PortifolioCarros.API"
                })
            );

            return services;
        }
    }
}
