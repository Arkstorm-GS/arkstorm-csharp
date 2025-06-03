namespace Arkstorm.Model
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string Impacto { get; set; }
        public DateTime DataHoraRegistro { get; set; }
    }
}