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
                return new List<Team>() {
                    new Team() {
                        TeamName = "Leganes",
                        YearofFoundation = 1970,
                        LeagueId = 1
                    },
                    new Team() {
                        TeamName = "Las Palmas",
                        YearofFoundation = 1899,
                        LeagueId = 1
                    },
                    new Team() {
                        TeamName = "Bournemouth",
                        YearofFoundation = 1885,
                        LeagueId = 3
                    },
                    new Team() {
                        TeamName = "Fulham",
                        YearofFoundation = 1902,
                        LeagueId = 3
                    },
                    new Team() {
                        TeamName = "Zaragoza",
                        YearofFoundation = 1899,
                        LeagueId = 1
                    },
                    new Team() {
                        TeamName = "Sheffield United",
                        YearofFoundation = 1924,
                        LeagueId = 3
                    }
                }.AsQueryable();
            }

            public Team Read(int teamId)
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
