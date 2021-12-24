using Repository.Models;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IActionPlayerSevice
    {
        Task<List<ActionPlayer>> GetAll();
        Task<List<ActionPlayer>> GetAllActionPlayers();
        Task<ActionPlayer> AddAsync(ActionPlayerDTO model);

        Task<ActionPlayer> UpdateAsync(ActionPlayer model);

        Task<ActionPlayer> GetAsyncById(int id);

        Task DeleteAsync(int id);
    }
}
