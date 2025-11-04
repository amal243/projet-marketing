namespace gestion_marketing.DTOs
{
    public class CreateCampagneDto
    {
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int CanalId { get; set; }
        public int PublicCibleId { get; set; }
    }
}
