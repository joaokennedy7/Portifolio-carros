namespace PortifolioCarros.API.DTOs
{
    public record GetCarsDto(int Id, string Name, string Brand, int Year, decimal Price, PhotoDto Photo);
    public record PhotoDto(string Url);
}
