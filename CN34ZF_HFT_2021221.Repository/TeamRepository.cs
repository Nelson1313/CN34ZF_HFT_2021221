using CN34ZF_HFT_2021221.Data;
using CN34ZF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Repository
{
    public class TeamRepository : ITeamRepository
    {
        TeamsDbContext context;

        public TeamRepository(TeamsDbContext context)
        {
            this.context = context;
        }

        public void Create(Team team)
        {
            context.Teams.Add(team);
            context.SaveChanges();
        }

        public Team Read(int teamId)
        {
            return context
                .Teams
                .FirstOrDefault(x => x.TeamId == teamId);
        }

        public IQueryable<Team> ReadAll()
        {
            return context.Teams;
        }

        public void Update(Team team)
        {
            Team old = Read(team.TeamId);

            // NULL CHECK

            old.TeamName = team.TeamName;
            old.YearofFoundation = team.YearofFoundation;
            old.Seat = team.Seat;
            old.Manager = team.Manager;

            context.SaveChanges();
        }

        public void Delete(int teamId)
        {
            context.Teams.Remove(Read(teamId));
            context.SaveChanges();
        }
    }
}
