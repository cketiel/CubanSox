namespace CubanSox.Backend.Models
{
    // Maestro: Resumen del equipo en el juego
    public class BoxScore
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }

        // Totales finales (Se calculan sumando innings o se guardan directo)
        public int R { get; set; } // Runs
        public int H { get; set; } // Hits
        public int E { get; set; } // Errors

        // Detalle: Lista de carreras por entrada
        public List<InningScore> Innings { get; set; } = new();
    }
}
