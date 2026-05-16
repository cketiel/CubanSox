using System.Text.Json.Serialization;

namespace CubanSox.Web.Models
{
    public class BattingStat
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        [JsonIgnore]
        public Player? Player { get; set; }
        public string Position { get; set; } // Posición defensiva durante el juego (P, C, 1B, 2B, 3B, SS, LF, CF, RF)
        public int Order { get; set; } // Orden al bate (1-9)
        public int AB { get; set; } // Veces al bate (VB)
        public int H { get; set; }  // Hits
        public int Doubles { get; set; } // 2B
        public int Triples { get; set; } // 3B
        public int HR { get; set; } // Jonrones
        public int BB { get; set; }  // Boletos
        public int SO { get; set; }  // Ponches (K)
        public int R { get; set; }  // Carreras anotadas (CA)
        public int RBI { get; set; } // Carreras Impulsadas (CI)
        public int SB { get; set; }  // Bases robadas
        public int HBP { get; set; } // Golpeado por lanzamiento
        public int SF { get; set; } // SAC + SF (Sacrifice Bunts + Sacrifice Flys) por simplicidad se pueden sumar ambos como SF
        public int E { get; set; } // Errores cometidos en el campo
        [JsonIgnore]
        public double AVG => AB > 0 ? (double)(H + Doubles + Triples + HR) / AB * 1000 : 0; // Average de bateo
        [JsonIgnore]
        public double SLG => AB > 0 ? (double)(H + 2 * Doubles + 3 * Triples + 4 * HR) / AB * 1000 : 0; // Slugging percentage
        [JsonIgnore]
        public double OBP => AB > 0 ? (double)(H + Doubles + Triples + HR + BB + HBP) / (AB + BB + HBP + SF) * 1000 : 0; // On-base percentage
        [JsonIgnore]
        public double OPS => AB > 0 ? OBP + SLG : 0; // OPS = OBP + SLG

        // Propiedad auxiliar para la interfaz
        [JsonIgnore]
        public int TempTeamId { get; set; }

        /*
         *  AB: At Bats (VB)
            SO: Strikeouts (K)
            R: Runs (CA)
            RBI: Runs Batted In (CI)
            SB: Stolen Bases (BR)
            HBP: Hit By Pitch (DB)
            SF: SAC + SF (Sacrifice Bunts + Sacrifice Flys)*/

    }
}
