namespace Arkstorm.Model
{
    public class Incidente
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Impacto { get; set; }
        public DateTime DataHora { get; set; }
    }
}