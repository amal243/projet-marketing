using System;
using System.Collections.Generic;

namespace gestion_marketing.Models
{
    public class Campagne
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        // === Relations ===
        public int CanalId { get; set; }
        public Canal? Canal { get; set; }

        public int PublicCibleId { get; set; }
        public PublicCible? PublicCible { get; set; }

        //  Relation Many-to-Many avec Client
        public ICollection<Client>? Clients { get; set; }

        // Relation avec les indicateurs de performance
        public ICollection<IndicateurPerformance>? Indicateurs { get; set; }
    }
}
