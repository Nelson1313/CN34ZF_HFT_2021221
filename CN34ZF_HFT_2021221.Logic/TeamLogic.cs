using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public class TeamLogic : ITeamLogic
    {

        ITeamRepository repo;

        public TeamLogic(ITeamRepository repo)
        {
            this.repo = repo;
        }
        public double AverageFoundation()
        {
            return repo
                .ReadAll()
                .Average(x => x.YearofFoundation);
        }

        public IEnumerable<KeyValuePair<string, double>>
            AverageFoundationByTeam()
        {
            return repo
                .ReadAll()
                .GroupBy(x => x.TeamName)
                .Select(x => new KeyValuePair<string, double>(
                    x.Key,
                    x.Average(x => x.YearofFoundation)));
        }

        public void Create(Team team)
        {
            repo.Create(team);
        }

        public Team ReadOne(int teamId)
        {
            return repo.ReadOne(teamId);
        }

        public void Delete(int teamId)
        {
            repo.Delete(teamId);
        }

        public IQueryable<Team> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Team team)
        {
            repo.Update(team);
        }

        public Team Read(int id)
        {
            return repo.ReadOne(id);
        }
    }
}
