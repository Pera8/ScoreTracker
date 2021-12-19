
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Models;
using Service;
using System.Threading.Tasks;
using TestScore.Service;
using Xunit;

namespace TestScore
{
    [TestClass]
    public class LeagueTest
    {
        private readonly LeagueRepositoryMock leagueRepository;
        private readonly LeagueService leagueService;

        public LeagueTest()
        {
            leagueRepository = new LeagueRepositoryMock();
            leagueService = new LeagueService(leagueRepository);
        }

        [TestMethod] 
        public async Task TestLeagueMethodGetAll()
        {
            // Act
            var result = await leagueService.GetAll();
            // Assert
            Assert.AreEqual(3, result.Count);          
        }

        [TestMethod]
        public async Task TestLeagueMethodGetById()
        {
            int id = 1;
            // Act
            var result = await leagueService.GetAsyncById(id);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "ITLiga");
        }

        [TestMethod]
        public async Task TestLeagueMethodAdd()
        {
            League league = new League()
            {
                Id = 4,
                Name = "MiniLiga",
                Address = "Pupinova 2",
                Logo = "zzzz"
            };
            // Act
            var result = await leagueService.AddAsync(league);
            var resultAllLeagues = await leagueService.GetAll();
            // Assert
            
            Assert.AreEqual(resultAllLeagues.Count, 4);
            CollectionAssert.Contains(resultAllLeagues, result);
        }

        [TestMethod]
        public async Task TestLeagueMethodDelete()
        {
            int id = 1;
            // Act
            var resultGetById = await leagueService.GetAsyncById(id);
            var result = leagueService.DeleteAsync(id);
            var resultAllLeagues = await leagueService.GetAll();
            
            // Assert

            Assert.AreEqual(resultAllLeagues.Count, 2);
            CollectionAssert.DoesNotContain(resultAllLeagues, resultGetById);
        }

    }
}
