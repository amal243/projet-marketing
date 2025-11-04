namespace gestion_marketing.DTOs
{
    public class UpdateCampagneDto
    {
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int? CanalId { get; set; }
        public int? PublicCibleId { get; set; }
    }
}
