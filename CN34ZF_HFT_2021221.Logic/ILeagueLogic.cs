﻿using CN34ZF_HFT_2021221.Models;
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

        League Read(int id);
        void Create(League league);
        IEnumerable<League> ReadAll();
        void Update(League league);
        void Delete(int leagueId);
    }
}