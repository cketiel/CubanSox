namespace CubanSox.Backend.Models
{
    // Detalle: Carreras en una entrada específica
    public class InningScore
    {
        public int Id { get; set; }
        public int BoxScoreId { get; set; }

        public int InningNumber { get; set; } // 1, 2, 3... 10, 11...
        public int Runs { get; set; }         // Carreras anotadas en esa entrada
    }
}
