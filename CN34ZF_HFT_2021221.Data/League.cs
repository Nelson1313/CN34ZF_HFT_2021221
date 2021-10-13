using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Data
{
    [Table("Leagues")]
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? LeagueId { get; set; }

        [ForeignKey(nameof(Country))]
        public int? CountryId { get; set; }

        public string LeagueName { get; set; }

        public int NumberofTeams { get; set; }

        public bool FirstClass { get; set; }


        [NotMapped]
        public string MainData => $"[{this.LeagueId}] {this.Country}, {this.LeagueName}, Country Id: {this.CountryId}, Number of teams: {this.NumberofTeams}, FirstClass: {this.FirstClass} ";

#nullable enable
        [NotMapped]
        public virtual Country? Country { get; set; }
#nullable disable

        public override string ToString()
        {
            return $"Id: {this.LeagueId}, Country of the league: {this.Country}, Name of the league: {this.LeagueName}, Country id: {this.CountryId}";
        }

        public override bool Equals(object obj)
        {
            if (obj is League)
            {
                League other = obj as League;
                return this.CountryId == other.CountryId &&
                    this.LeagueId == other.LeagueId &&
                    this.FirstClass == other.FirstClass &&
                    this.NumberofTeams == other.NumberofTeams &&
                    this.LeagueName == other.LeagueName &&
                    this.Country == other.Country;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)this.LeagueId + this.FirstClass.GetHashCode();
        }
    }
}
