using System;

namespace gestion_marketing.Models
{
    public class HistoriqueAction
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime DateAction { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}
