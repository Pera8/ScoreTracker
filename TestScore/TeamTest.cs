using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Models;
using Service;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestScore.Service;

namespace TestScore
{
    [TestClass]
    public class TeamTest
    {
        private readonly TeamRepositoryMock teamRepository;
        private readonly LeagueRepositoryMock leagueRepository;
        private readonly TeamService teamService;

        public TeamTest()
        {
            teamRepository = new TeamRepositoryMock();
            leagueRepository = new LeagueRepositoryMock();
            teamService = new TeamService(teamRepository,leagueRepository);

        }

        [TestMethod]
        public async Task TestTeamMethodGetAll()
        {
            // Act
            var result = await teamService.GetAll();
            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task TestTeamMethodGetById()
        {
            int id = 1;
            // Act
            var result = await teamService.GetAsyncById(id);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "Enigma");
        }

        [TestMethod]
        public async Task TestTeamMethodAdd()
        {
           
            TeamDTO team = new TeamDTO()
            {
                Id = 4,
                Name = "Radnicki",
                Address = "Pupinova 2",
                Logo = "zzzz",
                LeagueID=1
            };
            // Act
            var result = await teamService.AddAsync(team);
            var resultAllTeams = await teamService.GetAll();
            // Assert

            Assert.AreEqual(resultAllTeams.Count, 4);
            CollectionAssert.Contains(resultAllTeams, result);
        }

        [TestMethod]
        public async Task TestTeamMethodDelete()
        {
            int id = 1;
            // Act
            var resultGetById = await teamService.GetAsyncById(id);
            var result = teamService.DeleteAsync(id);
            var resultAllTeams = await teamService.GetAll();

            // Assert

            Assert.AreEqual(resultAllTeams.Count, 2);
            CollectionAssert.DoesNotContain(resultAllTeams, resultGetById);
        }
    }
}
