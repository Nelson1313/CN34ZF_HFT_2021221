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
    public class CountryController : ControllerBase
    {
        ICountryLogic logic;

        public CountryController(ICountryLogic countryLogic)
        {
            logic = countryLogic;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {

            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Country Get(int id)
        {

            return logic.Read(id);
        }


        [HttpPost]
        public void Post([FromBody] Country country)
        {

            logic.Create(country);
        }

        [HttpPut]
        public void Put([FromBody] Country country)
        {

            logic.Update(country);
        }

        [HttpDelete("{Id}")]
        public void Delete(int countryId)
        {

            logic.Delete(countryId);
        }
    }
}
