namespace PortifolioCarros.API.DTOs
{
    public record GetCarsDto(int Id, string Name, string Brand, int Year, string UrlPhoto, decimal Price);
}
