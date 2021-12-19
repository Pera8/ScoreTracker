using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ILeagueService
    {
        Task<List<League>> GetAll();
        Task<League> AddAsync(League model);

        Task<League> UpdateAsync(League model);

        Task<League> GetAsyncById(int id);

        Task DeleteAsync(int id);
    }
}
