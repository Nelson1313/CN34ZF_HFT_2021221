using CN34ZF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public interface ILeagueLogic
    {
        double AverageNumberofTeams();

        IEnumerable<KeyValuePair<string, double>>
            AverageNumberofTeamsByLeague();

        void Create(League league);
        IQueryable<League> ReadAll();
        void Update(League league);
        void Delete(int leagueId);
    }
}
