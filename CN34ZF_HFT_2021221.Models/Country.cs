using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [ForeignKey(nameof(League))]
        public int? LeagueId { get; set; }

        public string CountryName { get; set; }

        public int Population { get; set; }

        public string Language { get; set; }

        public int Area { get; set; }

        [NotMapped]
        public string MainData => $"[{this.CountryId}] : {this.CountryName}, (Population: {this.Population}) (Language: {this.Language}) (Area: {this.Area}) ";

        [NotMapped]
        public virtual ICollection<Team> Teams { get; }

        [NotMapped]
        public virtual ICollection<League> Leagues { get; }

        public override string ToString()
        {
            return $"Id: {this.CountryId}, Name: {this.CountryName}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Country)
            {
                Country other = obj as Country;
                return this.CountryId == other.CountryId &&
                    this.CountryName == other.CountryName &&
                    this.Area == other.Area;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return (int)this.CountryId + this.Area.GetHashCode();
        }
    }
}
