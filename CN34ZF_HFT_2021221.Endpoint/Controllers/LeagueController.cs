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
        private ILeagueLogic logic;

        public LeagueController(ILeagueLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("test")]
        public string Test()
        {

            return "TESTEST";
        }

        [HttpGet]
        public IEnumerable<League> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpPost]
        public void CreateOne([FromBody] League league)
        {

            logic.Create(league);
        }

        [HttpPut]
        public void UpdateOne([FromBody] League league)
        {

            logic.Update(league);
        }

        [HttpDelete("{leagueId}")]
        public void DeleteOne([FromRoute] int leagueId)
        {

            logic.Delete(leagueId);
        }
    }
}
