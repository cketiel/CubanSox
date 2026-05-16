namespace CubanSox.Web.Models
{
    public class BoxScore
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public int R { get; set; }
        public int H { get; set; }
        public int E { get; set; }
        public List<InningScore> Innings { get; set; } = new();
    }
}
