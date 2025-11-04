namespace gestion_marketing.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty;
        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}
