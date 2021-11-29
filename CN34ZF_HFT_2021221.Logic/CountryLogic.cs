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
        public double AveragePopulation()
        {
            return repo
                .ReadAll()
                .Average(x => x.Population);
        }

        public IEnumerable<KeyValuePair<string, double>>
            AveragePopulationByCountry()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.CountryName)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key,
                    x.Average(x => x.Population)));
        }

        public Country Read(int id)
        {
            return repo.ReadOne(id);
        }

        public void Create(Country country)
        {
            repo.Create(country);
        }

        public Country ReadOne(int countryId)
        {
            return repo.ReadOne(countryId);
        }

        public void Delete(int countryId)
        {
            repo.Delete(countryId);
        }

        public IQueryable<Country> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Country country)
        {
            repo.Update(country);
        }
    }
}
