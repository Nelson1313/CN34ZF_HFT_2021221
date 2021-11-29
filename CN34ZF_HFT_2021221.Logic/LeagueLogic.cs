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
            AverageNumberofTeamsByLeague()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.LeagueName)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key,
                    x.Average(x => x.NumberofTeams)));
        }

        public League Read(int id)
        {
            return repo.ReadOne(id);
        }
        public void Create(League league)
        {
            repo.Create(league);
        }

        public League ReadOne(int leagueId)
        {
            return repo.ReadOne(leagueId);
        }

        public void Delete(int leagueId)
        {
            repo.Delete(leagueId);
        }

        public IQueryable<League> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(League league)
        {
            repo.Update(league);
        }
    }
}
