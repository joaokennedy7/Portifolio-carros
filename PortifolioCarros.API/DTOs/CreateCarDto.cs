namespace PortifolioCarros.API.DTOs
{
    public record CreateOrUpdateCarDto(string Name, string Description, string Brand, int Year, decimal Price, string TechnicalDescription, List<string> Photos);
}
