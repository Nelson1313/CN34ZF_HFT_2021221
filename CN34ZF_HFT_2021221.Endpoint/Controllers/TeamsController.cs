using CN34ZF_HFT_2021221.Endpoint.Services;
using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CN34ZF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        ITeamLogic tl;
        IHubContext<SignalRHub> hub;

        public TeamsController(ITeamLogic tl, IHubContext<SignalRHub> hub)
        {
            this.tl = tl;
            this.hub = hub;
        }

        // GET: /teams
        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.tl.ReadAll();
        }

        // GET /teams/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return this.tl.Read(id);
        }

        // POST /teams
        [HttpPost]
        public void Post([FromBody] Team value)
        {
            this.tl.Create(value);
            this.hub.Clients.All.SendAsync("TeamCreated", value);
        }

        // PUT /teams
        [HttpPut]
        public void Put([FromBody] Team value)
        {
            this.tl.Update(value);
            this.hub.Clients.All.SendAsync("TeamUpdated", value);
        }

        // DELETE /teams/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teamToDelete = this.tl.Read(id);
            this.tl.Delete(id);
            this.hub.Clients.All.SendAsync("TeamDeleted", teamToDelete);
        }
    }
}
