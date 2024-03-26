using Microsoft.AspNetCore.Http.HttpResults;

namespace PortifolioCarros.API.DTOs
{
    public record CarDetailDto(int Id, string Name, string Brand, int Year, List<string> Photos, string Description, string TechnicalDescription, decimal Price, DateTime CreatedAt);
}
