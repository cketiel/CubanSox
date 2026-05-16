namespace CubanSox.Web.Models
{
    public class PitchingStat
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public double IP { get; set; } // Innings lanzados (ej: 5.1)
        public int H { get; set; } // Hits permitidos
        public int R { get; set; } // Carreras permitidas
        public int ER { get; set; } // Carreras limpias
        public int BB { get; set; } // Boletos otorgados
        public int SO { get; set; } // Ponches (K)
        public int HR { get; set; } // Jonrones permitidos
        public int W { get; set; } // Victoria (0 o 1)
        public int L { get; set; } // Derrota (0 o 1)
        public int S { get; set; } // Salvado (0 o 1)

        public double ERA => IP > 0 ? (double)(ER / IP) * 9 : 0; // Earned Run Average (ERA) = (ER / IP) * 9
    }
}
