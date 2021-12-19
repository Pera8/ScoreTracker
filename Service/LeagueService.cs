using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LeagueService : ILeagueService
    {
        private readonly IRepository<League> leagueRepository;

        public LeagueService(IRepository<League> leagueRepository)
        {
            this.leagueRepository = leagueRepository;
        }

        public async Task<League> AddAsync(League model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }                     

            return await leagueRepository.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var leagueDelete = await leagueRepository.GetAsyncById(id);
            if (leagueDelete == null)
            {
                throw new KeyNotFoundException("No league ");
            }
            await leagueRepository.DeleteAsync(id);
        }

        public async Task<List<League>> GetAll()
        {
            var result= await leagueRepository.GetAll();
            return result;
        }

        public async Task<League> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id must be bigger than 0");
            }
            var result = await leagueRepository.GetAsyncById(id);
            return result;
        }

        public async Task<League> UpdateAsync(League model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }

            return await leagueRepository.UpdateAsync(model);
        }

    }
}
