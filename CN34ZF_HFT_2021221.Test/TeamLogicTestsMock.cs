using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Test
{
    [TestFixture]
    public class TeamLogicTestsMock
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
        public TeamLogicTestsMock()
        {

            mockCountryRepository.Setup((c) => c.Create(It.IsAny<Country>()));
            mockCountryRepository.Setup((c) => c.ReadAll()).Returns(
                new List<Country>()
                {
                    new Country()
                    {
                        CountryId = 1,
                        CountryName = "Hungary",
                        Population = 9750000,
                        Language = "Hungarian"
                    },
                    new Country()
                    {
                        CountryId = 2,
                        CountryName = "Germany",
                        Population = 83240000,
                        Language = "German"
                    }
                }.AsQueryable());

            cl = new CountryLogic(mockCountryRepository.Object);


            mockLeagueRepository.Setup((l) => l.Create(It.IsAny<League>()));
            mockLeagueRepository.Setup((l) => l.ReadAll()).Returns(
                new List<League>()
                {
                    new League()
                    {
                        LeagueId = 5,
                        LeagueName = "Bundesliga",
                        LeagueRanking = 3,
                        CountryId = 5
                    },
                    new League()
                    {
                        LeagueId = 4,
                        LeagueName = "NB1",
                        LeagueRanking = 28,
                        CountryId = 4
                    }
                }.AsQueryable());

            ll = new LeagueLogic(mockLeagueRepository.Object);

            mockTeamRepository.Setup((t) => t.Create(It.IsAny<Team>()));
            mockTeamRepository.Setup((t) => t.ReadAll()).Returns(
                new List<Team>()
                {
                    new Team()
                    {
                        TeamId = 61,
                        TeamName = "Borussia Dortmund",
                        YearofFoundation = 1944,
                        LeagueId = 5
                    },
                    new Team()
                    {
                        TeamId = 62,
                        TeamName = "Debreceni VSC",
                        YearofFoundation = 1899,
                        LeagueId = 4
                    }
                }.AsQueryable());

            tl = new TeamLogic(mockTeamRepository.Object);
        }

        [Test]
        public void AverageFoundation()
        {
            //ACT
            var result = tl.AverageFoundation();

            //ASSERT
            Assert.That(result, Is.EqualTo(1921.5));
        }

        [Test]
        public void AverageFoundationByTeam()
        {
            //ACT
            var result = tl.AverageFoundationByTeam().ToArray();

            //ASSERT
            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, double>
                ("Borussia Dortmund", 1944)));
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

        //[Test]
        //public void TeamRead()
        //{
        //    Team team = tl.Read(61);

        //    Assert.That(team.TeamId, Is.EqualTo(61));
        //    Assert.That(team.YearofFoundation, Is.EqualTo(1944));
        //}

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
