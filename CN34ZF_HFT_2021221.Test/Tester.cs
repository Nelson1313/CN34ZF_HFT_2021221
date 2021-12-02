using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CN34ZF_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {

        TeamLogic tl;
        CountryLogic cl;
        LeagueLogic ll;

        Mock<ICountryRepository> mockCountryRepository =
            new Mock<ICountryRepository>();
        Mock<ILeagueRepository> mockLeagueRepository =
            new Mock<ILeagueRepository>();
        Mock<ITeamRepository> mockTeamRepository =
            new Mock<ITeamRepository>();

        [SetUp]
        public void Init()
        {
            var countries = new List<Country>()
                    {
                    new Country()
                    {
                        CountryId = 10,
                        CountryName = "Hungary",
                        Population = 9750000,
                        Language = "Hungarian"
                    },
                    new Country()
                    {
                        CountryId = 10,
                        CountryName = "Germany",
                        Population = 83240000,
                        Language = "German"
                    }
                }.AsQueryable();

            mockCountryRepository.Setup((c) => c.ReadAll()).Returns(countries);

            cl = new CountryLogic(mockCountryRepository.Object);

            Country fakeCountry = new Country();
            fakeCountry.CountryId = 4;
            fakeCountry.CountryName = "Hungary";
            var leagues = new List<League>()
                {
                    new League()
                    {
                        LeagueId = 5,
                        LeagueName = "NB1",
                        NumberofTeams = 30,
                        Country = fakeCountry
                    },
                    new League()
                    {
                        LeagueId = 6,
                        LeagueName = "NB2",
                        NumberofTeams = 15,
                        Country = fakeCountry
                    }
                }.AsQueryable();

            mockLeagueRepository.Setup((l) => l.ReadAll()).Returns(leagues);

            ll = new LeagueLogic(mockLeagueRepository.Object);

            League fakeLeague = new League();
            fakeLeague.LeagueId = 4;
            fakeLeague.LeagueName = "Bundesliga";
            var teams = new List<Team>()
            {
                    new Team()
                    {
                        TeamId = 61,
                        TeamName = "Borussia Dortmund",
                        YearofFoundation = 1944,
                        League = fakeLeague
                    },
                    new Team()
                    {
                        TeamId = 62,
                        TeamName = "Debreceni VSC",
                        YearofFoundation = 1899,
                        League = fakeLeague
                    }
             }.AsQueryable();

            mockTeamRepository.Setup((t) => t.ReadAll()).Returns(teams);

            tl = new TeamLogic(mockTeamRepository.Object);
        }
        [Test]
        public void AverageFoundationTest()
        {
            //ACT
            var result = tl.AverageFoundation();

            //ASSERT
            Assert.That(result, Is.EqualTo(1921.5));
        }

        [Test]
        public void LowestFoundationTest()
        {
            //ACT
            var result = tl.LowestFoundation();

            //ASSERT
            Assert.That(result, Is.EqualTo(1899));
        }

        [Test]
        public void AverageFoundationByTeamTest()
        {
            //ACT
            var result = tl.AverageFoundationByLeague();

            //ASSERT
            var excepted = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Bundesliga", 1921.5)
            };
            Assert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void HighestNumberofTeamsByCountryTest()
        {
            //ACT
            var result = ll.HighestNumberofTeamsByCountry();

            //ASSERT
            var excepted = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Hungary", 30)
            };
            Assert.That(result, Is.EqualTo(excepted));
        }

        [Test]
        public void AverageNumberofTeamsByCountryTest()
        {
            //ACT
            var result = ll.AverageNumberofTeamsByCountry();

            //ASSERT
            var excepted = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Hungary", 22.5)
            };
            Assert.That(result, Is.EqualTo(excepted));
        }

        [TestCase(3000, true)]
        public void CreateTeamTest(int foundation, bool result)
        {

            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => tl.Create(new Team()
                {
                    TeamName = "AS Saint-Étienne",
                    YearofFoundation = foundation
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => tl.Create(new Team()
                {
                    TeamName = "RC Lens",
                    YearofFoundation = foundation
                }), Throws.Exception);
            }

        }
        [Test]
        public void CountryCreate()
        {
            Country newCountry = new Country() { CountryName = "Belgium" };

            cl.Create(newCountry);
            mockCountryRepository.Verify(c => c.Create(newCountry), Times.Once);

        }

        [Test]
        public void LeagueCreate()
        {
            League newLeague = new League() { LeagueName = "Belgian First Division A" };

            ll.Create(newLeague);
            mockLeagueRepository.Verify(c => c.Create(newLeague), Times.Once);

        }

        [Test]
        public void TeamCreate()
        {
            Team newTeam = new Team() { TeamName = "Anderlecht" };

            tl.Create(newTeam);
            mockTeamRepository.Verify(c => c.Create(newTeam), Times.Once);

        }

        [Test]
        public void TeamDelete()
        {
            tl.Delete(61);
            mockTeamRepository.Verify(t => t.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void LeagueDelete()
        {
            ll.Delete(4);
            mockLeagueRepository.Verify(t => t.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
