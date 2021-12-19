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
    public class TeamRepositoryMock : IRepository<Team>
    {
        private readonly List<Team> teams;

        public TeamRepositoryMock()
        {
            teams = new List<Team>()
            {
                new Team(){Id=1,Name="Enigma",Address="Marka Miljanova 2", Logo="aaaa",  },
                new Team(){Id=2,Name="Prvacici",Address="Marka Miljanova 5", Logo="bbbb"},
                new Team(){Id=3,Name="CSKA",Address="Marka Miljanova 7", Logo="cccc"},
            };
        }

        public async Task<Team> AddAsync(Team model)
        {
            teams.Add(model);
            var result = teams.FirstOrDefault(e => e.Id == model.Id);
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var result = teams.FirstOrDefault(e => e.Id == id);
            teams.Remove(result);
        }

        public async Task<List<Team>> GetAll()
        {
            return teams;
        }

        public Task<DbSet<Team>> GetAllSet()
        {
            throw new NotImplementedException();
        }

        public async Task<Team> GetAsyncById(int id)
        {
            var result = teams.FirstOrDefault(e => e.Id == id);
            return result;
        }

        public Task<Team> UpdateAsync(Team model)
        {
            throw new NotImplementedException();
        }
    }
}
