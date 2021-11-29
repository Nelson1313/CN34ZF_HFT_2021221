using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Logic
{
    [Route("[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        ILeagueLogic logic;

        public LeagueController(ILeagueLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<League> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public League Get(int id)
        {

            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] League league)
        {

            logic.Create(league);
        }

        [HttpPut]
        public void Put([FromBody] League league)
        {

            logic.Update(league);
        }

        [HttpDelete("{id}")]
        public void Delete(int leagueId)
        {

            logic.Delete(leagueId);
        }
    }
}
