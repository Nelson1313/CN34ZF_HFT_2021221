using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public class CountryLogic : ICountryLogic
    {
        ICountryRepository repo;

        public CountryLogic(ICountryRepository repo)
        {
            this.repo = repo;
        }
        public double LowestPopulation()
        {
            return repo
                .ReadAll()
                .Average(x => x.Population);
        }

        public IEnumerable<KeyValuePair<string, double>>
            LowestPopulationByCountry()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.CountryName)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key,
                    x.Min(x => x.Population)));
        }

        public Country Read(int countryId)
        {
            return repo.Read(countryId);
        }

        public void Create(Country country)
        {
            repo.Create(country);
        }


        public void Delete(int countryId)
        {
            repo.Delete(countryId);
        }

        public IEnumerable<Country> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Country country)
        {
            repo.Update(country);
        }
    }
}
