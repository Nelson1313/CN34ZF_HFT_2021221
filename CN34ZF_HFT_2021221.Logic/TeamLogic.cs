using CN34ZF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public class TeamLogic
    {
        ITeamLogic repo;

        public TeamLogic(ITeamLogic repo)
        {
            this.repo = repo;
        }

        //public double AverageFoundation()
        //{
        //    return repo
        //        .ReadAll()
        //        .Average(x => x.YearofFoundation) ?? 0;
        //}

        //public IEnumerable<KeyValuePair<string, double>>
        //    AverageFoundationByTeams()
        //{
        //    return repo
        //        .ReadAll()
        //        .GroupBy(x => x.TeamName)
        //        .Select(x => new KeyValuePair<string, double>(
        //            x.Key.TeamName,
        //            x.Average(x => x.YearofFoundation) ?? 0));
        //}
    }
}
