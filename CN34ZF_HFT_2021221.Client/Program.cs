using CN34ZF_HFT_2021221.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CN34ZF_HFT_2021221.Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:56403");

            var countries = rest.Get<Country>("countries");
            var leagues = rest.Get<League>("leagues");

            var averagefoundation = rest.GetSingle<double>("stat/averagefoundation");
            var averagefoundationbyleague = rest.Get<KeyValuePair<string, double>>("stat/averagefoundationbyleague");
            ;
            //var menu = new ConsoleMenu()
            //    .Add(">>COUNTRIES<<", () => )
            //    .Add(" \t >>List of average number of teams/country<<", () => )
            //    .Add(" \t >>List of the highest number of teams/country<<", () => )
            //    .Add(" \t >>Change language<<", () => )
            //    .Add(" \t >>Change country name<<", () => )
            //    .Add(" \t >>Change language<<", () => )
            //    .Add(" \t >>Get Country by ID<<", () => )
            //    .Add(" \t >>Add Country<<.", () => )
            //    .Add(" \t >>Remove Country<<", () => )
            //    .Add(">>LEAGUES<<", () => )
            //    .Add(" \t >>List of the highest number of teams/country<<", () => )
            //    .Add(" \t >>List of the highest number of teams/country<<", () => )
            //    .Add(" \t >>Change league name<<", () => )
            //    .Add(" \t >>Change number of teams<<", () => )
            //    .Add(" \t >>Get League by ID<<", () => )
            //    .Add(" \t >>Add Leagaue<<.", () => )
            //    .Add(" \t >>Remove League<<", () => )
            //    .Add(">>TEAMS<<", () => )
            //    .Add(" \t >>Change team name<<", () => )
            //    .Add(" \t >>Change manager<<", () => )
            //    .Add(" \t >>Get Team by ID<<", () => )
            //    .Add(" \t >>Add Team<<.", () => )
            //    .Add(" \t >>Remove Team<<", () => )
            //    .Add(">>EXIT<<", ConsoleMenu.Close);
            //menu.Show();
        }

        //private static void ListAllCountries()
        //{
        //    Console.WriteLine("BRANDS: ");
        //    mobileLogic.GetAllBrands()
        //        .ToList()
        //        .ForEach(x => Console.WriteLine("\t" + x.MainData));
        //    Console.WriteLine("Press any key to return...");
        //    Console.ReadLine();
        //}
    }
}
