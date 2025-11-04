namespace gestion_marketing.Models
{
    public class IndicateurPerformance
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public double Valeur { get; set; }

        public int CampagneId { get; set; }
        public Campagne? Campagne { get; set; }
    }
}
