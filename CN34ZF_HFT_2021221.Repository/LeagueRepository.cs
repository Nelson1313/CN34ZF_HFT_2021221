using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Repository
{
    public class LeagueRepository : ILeagueRepository
    {
        TeamsDbContext context;

        public LeagueRepository(TeamsDbContext context)
        {
            this.context = context;
        }

        public void Create(League league)
        {
            context.Leagues.Add(league);
            context.SaveChanges();
        }

        public League Read(int leagueId)
        {
            return context
                .Leagues
                .FirstOrDefault(x => x.LeagueId == leagueId);
        }

        public IQueryable<League> ReadAll()
        {
            return context.Leagues;
        }

        public void Update(League league)
        {
            League old = Read(league.LeagueId);

            // NULL CHECK

            old.LeagueName = league.LeagueName;
            old.NumberofTeams = league.NumberofTeams;
            old.LeagueRanking = league.LeagueRanking;

            context.SaveChanges();
        }

        public void Delete(int leagueId)
        {
            context.Leagues.Remove(Read(leagueId));
            context.SaveChanges();
        }
    }
}
