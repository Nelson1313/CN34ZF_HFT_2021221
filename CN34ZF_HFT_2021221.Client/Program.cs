using CN34ZF_HFT_2021221.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CN34ZF_HFT_2021221.Client
{
    internal class Program
    {
        public static RestService rest = new RestService("http://localhost:56403");
        public static void Main(string[] args)
        {

            var countries = rest.Get<Country>("countries");
            //Console.WriteLine("Összes ország: " + countries);

            


            var averagefoundation = rest.GetSingle<double>("stat/averagefoundation");
            //Console.WriteLine("Átlagos alapítási év: " + averagefoundation);

            var averagefoundationbyleague = rest.Get<KeyValuePair<string, double>>("stat/averagefoundationbyleague");
            // Console.WriteLine("Átlagos alapítási év ligánként: " + averagefoundationbyleague);

            var subCountryMenu = new ConsoleMenu(args, level: 1)
                .Add(">> LIST ALL", () => ListAllCountries())
                .Add(">> GET BY ID", () => GetCountryByID())
                .Add(">> ADD ONE", () => AddCountry())
                .Add(">> DELETE ONE", () => DeleteCountry())
                .Add(">> UPDATE ONE", () => UpdateCountry())
               .Add(">> BACK", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "COUNTRIES MENU";
               });

            var subLeagueMenu = new ConsoleMenu(args, level: 1)
               .Add(">> LIST ALL LEAGUE", () => ListAllLeagues())
               .Add(">> GET BY ID", () => GetLeagueByID())
               .Add(">> ADD ONE", () => AddLeague())
               .Add(">> DELETE ONE", () => DeleteLeague())
               .Add(">> UPDATE ONE", () => UpdateLeague())
               .Add(">> BACK", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "LEAGUES MENU";
               });

            var subTeamMenu = new ConsoleMenu(args, level: 1)
               .Add(">> LIST ALL TEAMS", () => ListAllTeams())
               .Add(">> GET BY ID", () => GetTeamByID())
               .Add(">> ADD ONE", () => AddTeam())
               .Add(">> DELETE ONE", () => DeleteTeam())
               .Add(">> UPDATE ONE", () => UpdateTeam())
               .Add(">> BACK", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "TEAMS MENU";


               });

            var subNonCrudMenu = new ConsoleMenu(args, level: 1)
               .Add(">> LIST ALL TEAMS", () => ListAllTeams())
               .Add(">> GET BY ID", () => GetTeamByID())
               //.Add(">> ADD ONE", () => AddOne())
               //.Add(">> DELETE ONE", () => Delete())
               //.Add(">> UPDATE ONE", () => Update())
               .Add(">> BACK", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "TEAMS MENU";


               });

            var menu = new ConsoleMenu(args, level: 0)
               .Add(">> COUNTRIES SUBMENU", subCountryMenu.Show)
               .Add(">> LEAGUES SUBMENU", subLeagueMenu.Show)
               .Add(">> TEAMS SUBMENU", subTeamMenu.Show)
               .Add(">> NON-CRUD SUBMENU", subNonCrudMenu.Show)
               .Add(">> EXIT", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.EnableWriteTitle = true;
                   config.Title = "menu title";
               });
            menu.Show();

        }

        private static void ListAllCountries()
        {
            Console.WriteLine("COUNTRIES: ");
            rest.Get<Country>("countries").ForEach(x => Console.WriteLine(x.CountryName));
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        private static void ListAllLeagues()
        {
            Console.WriteLine("LEAGUES: ");
            rest.Get<League>("leagues").ForEach(x => Console.WriteLine(x.LeagueName));
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        private static void ListAllTeams()
        { 
            Console.WriteLine("TEAMS: ");
            rest.Get<Team>("teams").ForEach(x => Console.WriteLine(x.TeamName));
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        private static void GetCountryByID()
        {
            Console.WriteLine("Kérem adjon meg egy ország ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            Country result = rest.GetSingle<Country>($"countries/{ID}");
            Console.WriteLine(result.CountryName);
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        private static void GetLeagueByID()
        {
            Console.WriteLine("Kérem adjon meg egy liga ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            League result = rest.GetSingle<League>($"leagues/{ID}");
            Console.WriteLine(result.LeagueName);
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        private static void GetTeamByID()
        {
            Console.WriteLine("Kérem adjon meg egy csapat ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            Team result = rest.GetSingle<Team>($"teams/{ID}");
            Console.WriteLine(result.TeamName);
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }
        public static void DeleteCountry()
        {
            Console.WriteLine("Kérem adjon meg egy ország ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            rest.Delete(ID, "countries");
            Console.WriteLine("Ország törölve!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }
        public static void DeleteLeague()
        {
            Console.WriteLine("Kérem adjon meg egy liga ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            rest.Delete(ID, "leagues");
            Console.WriteLine("Liga törölve!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public static void DeleteTeam()
        {
            Console.WriteLine("Kérem adjon meg egy csapat ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            rest.Delete(ID, "teams");
            Console.WriteLine("Csapat törölve!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public static void AddCountry()
        {
            Country item = new Country();
            Console.WriteLine("Kérem adjon meg egy ország nevet: ");
            string name = Console.ReadLine();
            item.CountryName = name;
            Console.WriteLine("Kérem adjon meg egy ország népességet: ");
            int population = int.Parse(Console.ReadLine());
            item.Population = population;
            Console.WriteLine("Kérem adjon meg egy ország nyelvet: ");
            string language = Console.ReadLine();
            item.Language = language;
            Console.WriteLine("Kérem adjon meg egy ország területet: ");
            int area = int.Parse(Console.ReadLine());
            item.Area = area; 

            rest.Post(item, "countries");
            Console.WriteLine("Ország létrehozva!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public static void AddLeague()
        {
            League item = new League();
            Console.WriteLine("Kérem adjon meg egy liga nevet: ");
            string name = Console.ReadLine();
            item.LeagueName = name;
            Console.WriteLine("Kérem adjon meg egy liga létszámot: ");
            int numberofteams = int.Parse(Console.ReadLine());
            item.NumberofTeams = numberofteams;
            Console.WriteLine("Kérem adjon meg egy liga rangsorolást: ");
            int leagueranking = int.Parse(Console.ReadLine());
            item.LeagueRanking = leagueranking;

            rest.Post(item, "leagues");
            Console.WriteLine("Liga létrehozva!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public static void AddTeam()
        {
            Console.WriteLine("Kérem adjon meg egy csapat ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            Team item = new Team();
            Console.WriteLine("Kérem adjon meg egy csapat nevet: ");
            string name = Console.ReadLine();
            item.TeamName = name;
            Console.WriteLine("Kérem adjon meg egy csapat alapítási évet: ");
            int population = int.Parse(Console.ReadLine());
            item.YearofFoundation = population;
            Console.WriteLine("Kérem adjon meg egy csapat stadiont: ");
            string seat = Console.ReadLine();
            item.Seat = seat;
            Console.WriteLine("Kérem adjon meg egy csapat menedzser nevet: ");
            string manager = Console.ReadLine();
            item.Manager = manager;

            rest.Post(item, "teams");
            Console.WriteLine("Csapat létrehozva!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }
        public static void UpdateCountry()
        {
            Console.WriteLine("Kérem adjon meg egy ország ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            Country old = rest.Get<Country>(ID, "countries");
            Console.WriteLine("Kérem adjon meg egy új ország nevet: ");
            string name = Console.ReadLine();
            old.CountryName = name;
            Console.WriteLine("Kérem adjon meg egy új ország népességet: ");
            int population = int.Parse(Console.ReadLine());
            old.Population = population;
            Console.WriteLine("Kérem adjon meg egy új ország nyelvet: ");
            string language = Console.ReadLine();
            old.Language = language;
            Console.WriteLine("Kérem adjon meg egy csapat új ország területet: ");
            int area = int.Parse(Console.ReadLine());
            old.Area = area;
            rest.Put(old, "countries");

            Console.WriteLine("Ország módosítva!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }
        public static void UpdateLeague()
        {
            Console.WriteLine("Kérem adjon meg egy liga ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            League old = rest.Get<League>(ID, "leagues");
            Console.WriteLine("Kérem adjon meg egy új liga nevet: ");
            string name = Console.ReadLine();
            old.LeagueName = name;
            Console.WriteLine("Kérem adjon meg egy csapat új liga rangsorolást: ");
            int leagueranking = int.Parse(Console.ReadLine());
            old.LeagueRanking = leagueranking;
            Console.WriteLine("Kérem adjon meg egy új csapat stadiont: ");
            int numberofteams = int.Parse(Console.ReadLine());
            old.NumberofTeams = numberofteams;
            rest.Put(old, "leagues");

            Console.WriteLine("Liga módosítva!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public static void UpdateTeam()
        {
            Console.WriteLine("Kérem adjon meg egy csapat ID-t: ");
            int ID = int.Parse(Console.ReadLine());
            Team old = rest.Get<Team>(ID, "teams");
            Console.WriteLine("Kérem adjon meg egy új csapat nevet: ");
            string name = Console.ReadLine();
            old.TeamName = name;
            Console.WriteLine("Kérem adjon meg egy csapat új alapítási évet: ");
            int yearoffoundation = int.Parse(Console.ReadLine());
            old.YearofFoundation = yearoffoundation;
            Console.WriteLine("Kérem adjon meg egy új csapat stadiont: ");
            string seat = Console.ReadLine();
            old.Seat = seat;
            Console.WriteLine("Kérem adjon meg egy csapat új menedzser nevet: ");
            string manager = Console.ReadLine();
            old.Manager = manager;
            rest.Put(old, "teams");

            Console.WriteLine("Csapat módosítva!");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }
    }
}
