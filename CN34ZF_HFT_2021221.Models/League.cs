using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Models
{
    [Table("Leagues")]
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public int NumberofTeams { get; set; }

        public int LeagueRanking { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Country Country { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        [NotMapped]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
