namespace PortifolioCarros.API.Entities
{
    public class Picture : Entity
    {
        public string Url { get; set; }
        public Car Car { get; set; }
    }
}
