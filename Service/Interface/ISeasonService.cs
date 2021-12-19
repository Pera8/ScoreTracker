using Repository.Models;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISeasonService
    {
        Task<List<Season>> GetAll();
        Task<List<Season>> GetAllSeasons();
        Task<Season> AddAsync(SeasonDTO model);

        Task<Season> UpdateAsync(Season model);

        Task<Season> GetAsyncById(int id);

        Task DeleteAsync(int id);
    }
}
