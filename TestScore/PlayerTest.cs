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

    public class PlayerTest
    {
        private readonly PlayerRepositoryMock playerRepository;
        private readonly TeamRepositoryMock teamRepository;
        private readonly PlayerService playerService;

        public PlayerTest()
        {
            playerRepository = new PlayerRepositoryMock();
            teamRepository = new TeamRepositoryMock();
            playerService = new PlayerService(playerRepository,teamRepository);
        }

        [TestMethod]
        public async Task TestPlayerMethodGetAll()
        {
            // Act
            var result = await playerService.GetAll();
            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task TestPlayerMethodGetById()
        {
            int id = 1;
            // Act
            var result = await playerService.GetAsyncById(id);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "MIka");
        }

        [TestMethod]
        public async Task TestPlayerMethodAdd()
        {
            PlayerDTO player = new PlayerDTO()
            {
                Id = 4,
                Name = "Biba",
                LastName = "Bibic",
                TeamID=1
            };
            // Act
            var result = await playerService.AddAsync(player);
            var resultAllPlayers = await playerService.GetAll();
            // Assert

            Assert.AreEqual(resultAllPlayers.Count, 4);
            CollectionAssert.Contains(resultAllPlayers, result);
        }

        [TestMethod]
        public async Task TestPlayerMethodDelete()
        {
            int id = 1;
            // Act
            var resultGetById = await playerService.GetAsyncById(id);
            var result = playerService.DeleteAsync(id);
            var resultAllTeams = await playerService.GetAll();

            // Assert

            Assert.AreEqual(resultAllTeams.Count, 2);
            CollectionAssert.DoesNotContain(resultAllTeams, resultGetById);
        }
    }
}
