namespace PortifolioCarros.API.Entities
{
    public class Car : Entity
    {
        public Car()
        {
            Pictures = new List<Picture>();
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? TechnicalDescription { get; set; }
        public bool Deletado { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
