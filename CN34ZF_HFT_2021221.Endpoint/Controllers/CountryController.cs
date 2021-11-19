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
        private ICountryLogic logic;

        public CountryController(ICountryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("test")]
        public string Test()
        {

            return "TESTEST";
        }

        [HttpGet]
        public IEnumerable<Country> GetAll()
        {

            return logic.ReadAll();
        }

        [HttpPost]
        public void CreateOne([FromBody] Country country)
        {

            logic.Create(country);
        }

        [HttpPut]
        public void UpdateOne([FromBody] Country country)
        {

            logic.Update(country);
        }

        [HttpDelete("{countryId}")]
        public void DeleteOne([FromRoute] int countryId)
        {

            logic.Delete(countryId);
        }
    }
}
