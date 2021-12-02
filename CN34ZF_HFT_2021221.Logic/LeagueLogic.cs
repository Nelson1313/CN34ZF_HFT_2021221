using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public class LeagueLogic : ILeagueLogic
    {
        ILeagueRepository repo;

        public LeagueLogic(ILeagueRepository repo)
        {
            this.repo = repo;
        }
        public double AverageNumberofTeams()
        {
            return repo
                .ReadAll()
                .Average(x => x.NumberofTeams);
        }

        public IEnumerable<KeyValuePair<string, double>>
            AverageNumberofTeamsByCountry()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.Country.CountryName)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key,
                    x.Average(x => x.NumberofTeams)));
        }

        public IEnumerable<KeyValuePair<string, double>>
            HighestNumberofTeamsByCountry()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.Country.CountryName)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key,
                    x.Max(x => x.NumberofTeams)));
        }

        public void Create(League league)
        {
            repo.Create(league);
        }

        public League Read(int leagueId)
        {
            return repo.Read(leagueId);
        }

        public void Delete(int leagueId)
        {
            repo.Delete(leagueId);
        }

        public IEnumerable<League> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(League league)
        {
            repo.Update(league);
        }
    }
}
