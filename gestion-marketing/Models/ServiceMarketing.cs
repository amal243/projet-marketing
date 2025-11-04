namespace gestion_marketing.Models
{
    public class ServiceMarketing
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Optionnel : relation avec d'autres entités
        public ICollection<Campagne>? Campagnes { get; set; }
    }
}
