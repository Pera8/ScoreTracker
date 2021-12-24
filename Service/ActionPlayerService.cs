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
    public class ActionPlayerService : IActionPlayerSevice
    {
        static ActionPlayerService() => MapperConfig.RegisterPlayerMapping();

        private readonly IRepository<ActionPlayer> actionPlayerRepository;
        private readonly IRepository<Player> playerRepository;

        public ActionPlayerService(IRepository<Player> playerRepository, IRepository<ActionPlayer> actionPlayerRepository)
        {
            this.playerRepository = playerRepository;
            this.actionPlayerRepository = actionPlayerRepository;
        }

        public ActionPlayerService(IRepository<ActionPlayer> actionPlayerRepository)
        {
            this.actionPlayerRepository = actionPlayerRepository;
        }

        public async Task<ActionPlayer> AddAsync(ActionPlayerDTO model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }
            var player = await playerRepository.GetAsyncById(model.PlayerId);

            if (player == null)
            {
                throw new KeyNotFoundException("Player can't be null");
            }

            var actionPlayer = new ActionPlayer()
            {
                Min = model.Min,
                ActionType = model.ActionType,
                Player =player
                
            };

            return await actionPlayerRepository.AddAsync(actionPlayer);
        }

        public async Task DeleteAsync(int id)
        {
            var actionPlayerDelete = await actionPlayerRepository.GetAsyncById(id);
            if (actionPlayerDelete == null)
            {
                throw new KeyNotFoundException("No league ");
            }
            await actionPlayerRepository.DeleteAsync(id);
        }

        public async Task<List<ActionPlayer>> GetAll()
        {
            var result = await actionPlayerRepository.GetAll();
            return result;
        }

        public async Task<List<ActionPlayer>> GetAllActionPlayers()
        {
            var result = await actionPlayerRepository.GetAllSet();
            return result.Include(x => x.Player).ToList();
        }

        public async Task<ActionPlayer> GetAsyncById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be bigger than 0");
            }
            var result = await actionPlayerRepository.GetAllSet();
            var actionPlayer = await result.Include(x => x.Player).FirstOrDefaultAsync();
            return actionPlayer;
        }

        public Task<ActionPlayer> UpdateAsync(ActionPlayer model)
        {
            throw new NotImplementedException();
        }
    }
}
