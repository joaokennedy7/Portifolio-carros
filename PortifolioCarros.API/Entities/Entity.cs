namespace PortifolioCarros.API.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
