using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Repository
{
    public class CountryRepository : ICountryRepository
    {
        TeamsDbContext context;

        public CountryRepository(TeamsDbContext context)
        {
            this.context = context;
        }

        public void Create(Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
        }

        public Country Read(int countryId)
        {
            return context
                .Countries
                .FirstOrDefault(x => x.CountryId == countryId);
        }

        public IQueryable<Country> ReadAll()
        {
            return context.Countries;
        }

        public void Update(Country country)
        {
            Country old = Read(country.CountryId);

            // NULL CHECK

            old.CountryName = country.CountryName;
            old.Population = country.Population;
            old.Area = country.Area;
            old.Language = country.Language;

            context.SaveChanges();
        }

        public void Delete(int countryId)
        {
            context.Countries.Remove(Read(countryId));
            context.SaveChanges();
        }
    }
}
