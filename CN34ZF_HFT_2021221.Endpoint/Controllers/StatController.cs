using CN34ZF_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CN34ZF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {

        ITeamLogic tl;
        ICountryLogic cl;
        ILeagueLogic ll;

        public StatController(ITeamLogic tl, ICountryLogic cl, ILeagueLogic ll)
        {
            this.tl = tl;
            this.cl = cl;
            this.ll = ll;
        }
        // GET: stat/avgfoundation
        [HttpGet]
        public double AverageFoundation()
        {
            return tl.AverageFoundation();
        }

        // GET: stat/lowestfoundation
        [HttpGet]
        public double LowestFoundation()
        {
            return tl.LowestFoundation();
        }

        // GET stat/lowestpopulation
        [HttpGet]
        public double LowestPopulation()
        {
            return cl.LowestPopulation();
        }

        // GET stat/averagepopulation
        [HttpGet]
        public double AveragePopulation()
        {
            return cl.AveragePopulation();
        }

        // GET: stat/averagenumberofteams
        [HttpGet]
        public double AverageNumberofTeams()
        {
            return ll.AverageNumberofTeams();
        }
    }
}
