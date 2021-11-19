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

            Country fakeCountry = new Country()
            {
                CountryName = "France"
            };

            mockTeamRepository.Setup((t) => t.Create(It.IsAny<Team>()));
            mockTeamRepository.Setup((t) => t.ReadAll()).Returns(
                new List<Team>()
                {
                    new Team()
                    {
                        TeamName = "Lille OSC",
                        YearofFoundation = 1944,
                        Country = fakeCountry
                    },
                    new Team()
                    {
                        TeamName = "Olympique de Marseille",
                        YearofFoundation = 1899,
                        Country = fakeCountry
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
            Assert.That(result, Is.EqualTo(1900));
        }

        [Test]
        public void AverageFoundationByTeam()
        {
            //ACT
            var result = tl.AverageFoundationByTeam().ToArray();

            //ASSERT
            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, double>
                ("Lille OSC", 1944)));
        }

        [TestCase(-3000, false)]
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
