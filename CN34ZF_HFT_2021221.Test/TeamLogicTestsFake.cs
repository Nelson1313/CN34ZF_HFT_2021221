using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Models;
using CN34ZF_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Test
{
    [TestFixture]
    class TeamLogicTestsFake
    {
        class FakeTeamRepository : ITeamRepository
        {
            public void Create(Team team)
            {
                throw new NotImplementedException();
            }

            public void Delete(int teamId)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Team> ReadAll()
            {
                Country c1 = new Country() { CountryName = "Ligue 1" };
                Country c2 = new Country() { CountryName = "NB1" };

                return new List<Team>() {
                    new Team() {
                        TeamName = "Paris Saint-Germain FC",
                        YearofFoundation = 1970,
                        Country = c1
                    },
                    new Team() {
                        TeamName = "Ferencvárosi TC",
                        YearofFoundation = 1899,
                        Country = c2
                    },
                    new Team() {
                        TeamName = "Újpest FC",
                        YearofFoundation = 1885,
                        Country = c2
                    },
                    new Team() {
                        TeamName = "Debreceni VSC",
                        YearofFoundation = 1902,
                        Country = c2
                    },
                    new Team() {
                        TeamName = "Olympique Lyonnais",
                        YearofFoundation = 1899,
                        Country = c1
                    },
                    new Team() {
                        TeamName = "AS Monaco FC",
                        YearofFoundation = 1924,
                        Country = c1
                    }
                }.AsQueryable();
            }

            public Team ReadOne(int teamId)
            {
                throw new NotImplementedException();
            }

            public void Update(Team team)
            {
                throw new NotImplementedException();
            }
        }

        ITeamLogic logic;

        [SetUp]
        public void Setup()
        {
            logic = new TeamLogic(new FakeTeamRepository());
        }

        [Test]
        public void CheckAverageFoundation()
        {
            double avg = logic.AverageFoundation();
            Assert.AreEqual(avg, 1913.16, 0.1);
        }
    }
}
