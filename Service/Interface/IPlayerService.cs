using Repository.Models;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAll();
        Task<List<Player>> GetAllPlayers();
        Task<Player> AddAsync(PlayerDTO model);

        Task<Player> UpdateAsync(Player model);

        Task<Player> GetAsyncById(int id);

        Task DeleteAsync(int id);
    }
}
