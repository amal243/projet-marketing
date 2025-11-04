using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_marketing.Models
{
    [Table("clients")] // Nom exact de la table dans PostgreSQL
    public class Client
    {
        [Column("id_client")]
        public int Id { get; set; }

        [Column("nom_client")]
        public string Nom { get; set; } = string.Empty;

        [Column("secteur")]
        public string? Secteur { get; set; }

        [Column("email_contact")]
        public string? Email { get; set; }

        [Column("telephone")]
        public string Telephone { get; set; } = string.Empty;

        [Column("ville")]
        public string? Ville { get; set; }

        [Column("pays")]
        public string? Pays { get; set; }

        // Relation inverse Many-to-Many (avec Campagne)
        public ICollection<Campagne>? Campagnes { get; set; }
    }
}
