using CN34ZF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public interface ICountryLogic
    {
        double LowestPopulation();

        IEnumerable<KeyValuePair<string, double>>
            LowestPopulationByCountry();

        Country Read(int id);
        void Create(Country country);
        IEnumerable<Country> ReadAll();
        void Update(Country country);
        void Delete(int countryId);
    }
}
