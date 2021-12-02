using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Models
{
    //[Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int Population { get; set; }

        public string Language { get; set; }

        public int Area { get; set; }


        [NotMapped]
        public virtual ICollection<League> Leagues { get; }

        public Country()
        {
            Leagues = new HashSet<League>();
        }

    }
}
