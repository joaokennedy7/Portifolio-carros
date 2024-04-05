namespace PortifolioCarros.API.DTOs
{
    public record GetCarsDto(int Id, string Name, string Brand, int Year, decimal Price, string UrlPhoto = "photo");
}
