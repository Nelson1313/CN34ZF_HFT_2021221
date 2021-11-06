using CN34ZF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Repository
{
    public interface ITeamRepository
    {
        // C(R)RUD
        void Create(Team team);
        Team ReadOne(int teamId);
        IQueryable<Team> ReadAll(); // query
        void Update(Team team);
        void Delete(int teamId);
    }
}
