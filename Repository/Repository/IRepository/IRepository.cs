using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IRepository <TModel> where TModel : class , IBaseModel
    {
        Task<List<TModel>> GetAll();

        Task<DbSet<TModel>> GetAllSet();
        Task<TModel> AddAsync(TModel model);

        Task<TModel> UpdateAsync(TModel model);

        Task<TModel> GetAsyncById(int id);

        Task DeleteAsync(int id);
    }
}
