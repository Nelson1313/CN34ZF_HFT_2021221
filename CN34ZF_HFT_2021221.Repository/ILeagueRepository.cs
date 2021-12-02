using CN34ZF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Repository
{
    public interface ILeagueRepository
    {
        // C(R)RUD
        void Create(League league);
        League Read(int leagueId);
        IQueryable<League> ReadAll(); // query
        void Update(League league);
        void Delete(int leagueId);
    }
}
