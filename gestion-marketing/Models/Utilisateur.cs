using System.Collections.Generic;

namespace gestion_marketing.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Utilisateur";
        public string MotDePasseHash { get; set; } = string.Empty;

        public ICollection<HistoriqueAction>? Actions { get; set; }
        public ICollection<Suggestion>? Suggestions { get; set; }
    }
}
