using CN34ZF_HFT_2021221.Models;
using System;
using System.Linq;

namespace CN34ZF_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:56403");
            rest.Post<Team>(new Team()
            {
                TeamName = "FTC"
            }, "country");

            var teams = rest.Get<Team>("team");
            var countries = rest.Get<Country>("country");
        }
    }
}
