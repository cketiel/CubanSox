namespace CubanSox.Backend.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        // no es correcto porque un jugador puede jugar en varias posiciones
        // public string Position { get; set; } // P, C, 1B, 2B, 3B, SS, LF, CF, RF
        public DateTime? DOB { get; set; }
        public string? Photo { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
