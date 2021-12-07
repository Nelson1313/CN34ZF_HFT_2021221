﻿using CN34ZF_HFT_2021221.Logic;
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
    public class TeamsController : ControllerBase
    {

        ITeamLogic tl;

        public TeamsController(ITeamLogic tl)
        {
            this.tl = tl;
        }

        // GET: /teams
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return tl.ReadAll();
        }

        // GET /teams/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return tl.Read(id);
        }

        // POST /teams
        [HttpPost]
        public void Post([FromBody] Team value)
        {
            tl.Create(value);
        }

        // PUT /teams
        [HttpPut]
        public void Put([FromBody] Team value)
        {
            tl.Update(value);
        }

        // DELETE /teams/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.Delete(id);
        }
    }
}