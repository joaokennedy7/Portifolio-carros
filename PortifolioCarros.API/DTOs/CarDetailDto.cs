namespace PortifolioCarros.API.DTOs
{
    public record CarDetailDto(int Id, string Name, string Brand, int Year, string? Description, string? TechnicalDescription, decimal Price, DateTime CriadoEm);
}
