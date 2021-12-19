using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Configuration;
using Service.Interface;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PlayerService : IPlayerService
    {
        static PlayerService() => MapperConfig.RegisterPlayerMapping();

        private readonly IRepository<Player> playerRepository;
        private readonly IRepository<Team> teamRepository;

        public PlayerService(IRepository<Player> playerRepository, IRepository<Team> teamRepository)
        {
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }

        public PlayerService(IRepository<Player> playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task<Player> AddAsync(PlayerDTO model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }
            var team = await teamRepository.GetAsyncById(model.TeamID);

            if (team == null)
            {
                throw new KeyNotFoundException("League can't be null");
            }

            var player = new Player()
            {
                Name = model.Name,
                LastName = model.LastName,
                Team = team
            };

            return await playerRepository.AddAsync(player);
        }

        public async Task DeleteAsync(int id)
        {
            var leagueDelete = await playerRepository.GetAsyncById(id);
            if (leagueDelete == null)
            {
                throw new KeyNotFoundException("No league ");
            }
            await playerRepository.DeleteAsync(id);
        }

        public async Task<List<Player>> GetAll()
        {
            var result = await playerRepository.GetAll();
            return result;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            var result = await playerRepository.GetAllSet();
            return result.Include(x => x.Team).ToList();
        }

        public async Task<Player> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id must be bigger than 0");
            }
            var result = await playerRepository.GetAllSet();
            var player = await result.Include(x => x.Team).FirstOrDefaultAsync();
            //var result = await playerRepository.GetAsyncById(id);
            return player;
        }

        public async Task<Player> UpdateAsync(Player model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }

            return await playerRepository.UpdateAsync(model);
        }
    }
}
