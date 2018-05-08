namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {

        [Required]
        [StringLength(2,MinimumLength = 2)]
        public string Id { get; set; }

        public string PositionDescription { get; set; }

        public ICollection<Player> Players { get; set; }  = new List<Player>();
    }
}
