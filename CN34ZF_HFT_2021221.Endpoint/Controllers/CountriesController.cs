using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        ICountryLogic cl;

        public CountriesController(ICountryLogic cl)
        {
            this.cl = cl;
        }

        // GET: /country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return cl.ReadAll();
        }

        // GET /country/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return cl.Read(id);
        }

        // POST /country
        [HttpPost]
        public void Post([FromBody] Country value)
        {
            cl.Create(value);
        }

        // PUT /country
        [HttpPut]
        public void Put([FromBody] Country value)
        {
            cl.Update(value);
        }

        // DELETE /country/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
