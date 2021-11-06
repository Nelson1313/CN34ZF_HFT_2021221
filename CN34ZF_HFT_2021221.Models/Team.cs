using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public int YearofFoundation { get; set; }

        public string Seat { get; set; }
        public string Manager { get; set; }

        [NotMapped]
        public string MainData => $"[{this.TeamId}] Country: {this.CountryId} , Team name: {this.TeamName}, Seat: {this.Seat}, Manager: {this.Manager}, Year of foundation: {this.YearofFoundation}";

#nullable enable
        [NotMapped]
        public virtual Country? Country { get; set; }
#nullable disable
        public int? CountryId { get; set; }

        public override string ToString()
        {
            return $"Id: {this.TeamId}, Country: {this.Country.CountryName}, Team name: {this.TeamName}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Team)
            {
                Team other = obj as Team;
                return this.TeamId == other.TeamId &&
                    this.CountryId == other.CountryId &&
                    this.TeamName == other.TeamName &&
                    this.Manager == other.Manager &&
                    this.Seat == other.Seat &&
                    this.YearofFoundation == other.YearofFoundation;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)this.TeamId + this.TeamName.GetHashCode();
        }
    }
}