using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScore.Service
{
    public class LeagueRepositoryMock : IRepository<League>
    {
        private readonly List<League> leagues;

        public LeagueRepositoryMock()
        {
            leagues = new List<League>()
            {
                new League(){Id=1,Name="ITLiga",Address="Marka Miljanova 2", Logo="aaaa"},
                new League(){Id=2,Name="Liga Prvacica",Address="Marka Miljanova 5", Logo="bbbb"},
                new League(){Id=3,Name="Liga bez briga",Address="Marka Miljanova 7", Logo="cccc"},
            };
        }

        public async Task<League> AddAsync(League model)
        {
            
             leagues.Add(model);
            var result = leagues.FirstOrDefault(e => e.Id == model.Id);
            return result;

        }

        public async Task DeleteAsync(int id)
        {
            var result = leagues.FirstOrDefault(e => e.Id == id);
            leagues.Remove(result);
        }

        public async Task<List<League>> GetAll()
        {
            return  leagues;
        }

        public Task<DbSet<League>> GetAllSet()
        {
            throw new NotImplementedException();
        }

        public async Task<League> GetAsyncById(int id)
        {
            var result=  leagues.FirstOrDefault(e => e.Id == id);
            return result;
        }

        public Task<League> UpdateAsync(League model)
        {
            throw new NotImplementedException();
        }
    }
}
