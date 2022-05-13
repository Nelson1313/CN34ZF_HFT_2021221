using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CN34ZF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {

        ILeagueLogic ll;

        public LeagueController(ILeagueLogic ll)
        {
            this.ll = ll;
        }

        // GET: /leagues
        [HttpGet]
        public IEnumerable<League> ReadAll()
        {
            return this.ll.ReadAll();
        }

        // GET /leagues/5
        [HttpGet("{id}")]
        public League Get(int id)
        {
            return this.ll.Read(id);
        }

        // POST /leagues
        [HttpPost]
        public void Post([FromBody] League value)
        {
            ll.Create(value);
        }

        // PUT /leagues
        [HttpPut]
        public void Put([FromBody] League value)
        {
            ll.Update(value);
        }

        // DELETE /leagues/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ll.Delete(id);
        }
    }
}
