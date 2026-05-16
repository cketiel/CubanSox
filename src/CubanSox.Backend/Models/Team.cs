using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace CubanSox.Backend.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Logo { get; set; }
        //public ICollection<Player> Players { get; set; }
    }
}
