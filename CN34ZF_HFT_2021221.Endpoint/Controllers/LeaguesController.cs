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
    public class LeaguesController : ControllerBase
    {

        ILeagueLogic ll;

        public LeaguesController(ILeagueLogic ll)
        {
            this.ll = ll;
        }

        // GET: /league
        [HttpGet]
        public IEnumerable<League> Get()
        {
            return ll.ReadAll();
        }

        // GET /league/5
        [HttpGet("{id}")]
        public League Get(int id)
        {
            return ll.Read(id);
        }

        // POST /league
        [HttpPost]
        public void Post([FromBody] League value)
        {
            ll.Create(value);
        }

        // PUT /league
        [HttpPut]
        public void Put([FromBody] League value)
        {
            ll.Update(value);
        }

        // DELETE /league/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ll.Delete(id);
        }
    }
}
