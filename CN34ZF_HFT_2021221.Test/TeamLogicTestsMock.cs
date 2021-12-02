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
        public TeamLogicTestsMock()
        {
            Mock<ITeamRepository> mockTeamRepository =
                new Mock<ITeamRepository>();

            League fakeLeague = new League()
            {
                LeagueName = "Bundesliga"
            };

            mockTeamRepository.Setup((t) => t.Create(It.IsAny<Team>()));
            mockTeamRepository.Setup((t) => t.ReadAll()).Returns(
                new List<Team>()
                {
                    new Team()
                    {
                        TeamName = "Borussia Dortmund",
                        YearofFoundation = 1944,
                        League = fakeLeague
                    },
                    new Team()
                    {
                        TeamName = "Bayern München",
                        YearofFoundation = 1899,
                        League = fakeLeague
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
    }
}
