namespace CubanSox.Web.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Logo { get; set; } // Aquí guardaremos el Base64
       // public ICollection<Player> Players { get; set; }
    }
}
