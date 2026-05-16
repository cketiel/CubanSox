namespace CubanSox.Backend.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Field { get; set; }
        public int HomeTeamId { get; set; }
        public int VisitorTeamId { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? VisitorTeam { get; set; }
    }
}
