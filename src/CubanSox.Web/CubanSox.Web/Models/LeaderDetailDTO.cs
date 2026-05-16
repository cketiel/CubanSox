namespace CubanSox.Web.Models
{
    public class LeaderDetailDTO
    {
        public int DisplayRank { get; set; }
        public string Name { get; set; } = "";
        public string? Photo { get; set; }
        public string? TeamLogo { get; set; }
        public double Value { get; set; }
    }
}
