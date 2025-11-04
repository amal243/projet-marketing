namespace gestion_marketing.DTOs
{
	public class CampagneDto
	{
		public int Id { get; set; }
		public string Nom { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string DateDebut { get; set; } = string.Empty;
		public string DateFin { get; set; } = string.Empty;

		public string? CanalNom { get; set; }
		public string? PublicCibleNom { get; set; }
	}
}
