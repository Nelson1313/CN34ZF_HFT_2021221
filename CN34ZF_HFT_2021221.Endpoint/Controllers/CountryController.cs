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
    public class CountryController : ControllerBase
    {

        ICountryLogic cl;

        public CountryController(ICountryLogic cl)
        {
            this.cl = cl;
        }

        // GET: /countries
        [HttpGet]
        public IEnumerable<Country> ReadAll()
        {
            return this.cl.ReadAll();
        }

        // GET /countries/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return this.cl.Read(id);
        }

        // POST /countries
        [HttpPost]
        public void Post([FromBody] Country value)
        {
            cl.Create(value);
        }

        // PUT /countries
        [HttpPut]
        public void Put([FromBody] Country value)
        {
            cl.Update(value);
        }

        // DELETE /countries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
