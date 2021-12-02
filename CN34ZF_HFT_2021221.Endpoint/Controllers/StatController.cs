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

        public StatController(ITeamLogic tl)
        {
            this.tl = tl;
        }
        // GET: stat/avgfoundation
        [HttpGet]
        public double AverageFoundation()
        {
            return tl.AverageFoundation();
        }

        // GET stat/averagefoundationbyleague
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AverageFoundationByLeague()
        {
            return tl.AverageFoundationByLeague();
        }

    }
}
