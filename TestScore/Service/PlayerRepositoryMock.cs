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
    public class PlayerRepositoryMock : IRepository<Player>
    {
        private readonly List<Player> players;

        public PlayerRepositoryMock()
        {
            players = new List<Player>()
            {
                new Player(){Id=1,Name="MIka",LastName="Mikic"  },
                new Player(){Id=2,Name="Zika",LastName="Zikic" },
                new Player(){Id=3,Name="Sima",LastName="Simic" },
            };
        }

        public async Task<Player> AddAsync(Player model)
        {
            players.Add(model);
            var result = players.FirstOrDefault(e => e.Id == model.Id);
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var result = players.FirstOrDefault(e => e.Id == id);
            players.Remove(result);
        }

        public async Task<List<Player>> GetAll()
        {
            return players;
        }

        public Task<DbSet<Player>> GetAllSet()
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetAllSet(string include)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetAsyncById(int id)
        {
            var result = players.FirstOrDefault(e => e.Id == id);
            return result;
        }

        public Task<Player> UpdateAsync(Player model)
        {
            throw new NotImplementedException();
        }
    
    }
}
