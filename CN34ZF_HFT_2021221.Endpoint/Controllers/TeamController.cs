using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HFT_FF_L09.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamLogic logic;

        public TeamController(ITeamLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Team> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Get(int id)
        {

            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Team team)
        {

            logic.Create(team);
        }

        [HttpPut]
        public void Put([FromBody] Team team)
        {

            logic.Update(team);
        }

        [HttpDelete("{id}")]
        public void Delete(int teamId)
        {

            logic.Delete(teamId);
        }
    }
}
