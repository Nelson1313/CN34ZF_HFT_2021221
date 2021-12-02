using CN34ZF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public interface ITeamLogic
    {
        double AverageFoundation();
        double LowestFoundation();

        IEnumerable<KeyValuePair<string, double>>
            AverageFoundationByLeague();

        Team Read(int id);
        void Create(Team team);
        IEnumerable<Team> ReadAll();
        void Update(Team team);
        void Delete(int teamId);
    }
}
