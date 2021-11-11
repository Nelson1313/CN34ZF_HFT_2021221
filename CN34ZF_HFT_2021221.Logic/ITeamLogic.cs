﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    public interface ITeamLogic
    {
        double AverageFoundation();

        IEnumerable<KeyValuePair<string, double>>
            AverageFoundationByTeams();
        object ReadAll();
    }
}
