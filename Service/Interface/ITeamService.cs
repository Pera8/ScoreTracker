using Repository.Models;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITeamService
    {
        Task<List<Team>> GetAll();
        Task<List<Team>> GetAllTeam();
        Task<Team> AddAsync(TeamDTO model);

        Task<Team> UpdateAsync(Team model);

        Task<Team> GetAsyncById(int id);

        Task DeleteAsync(int id);
    }
}
