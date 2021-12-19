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
    public class SeasonService : ISeasonService
    {
        static SeasonService() => MapperConfig.RegisterSeasonMapping();

        private readonly IRepository<Season> seasonRepository;
        private readonly IRepository<League> leagueRepository;

        public SeasonService(IRepository<Season> seasonRepository, IRepository<League> leagueRepository)
        {
            this.seasonRepository = seasonRepository;
            this.leagueRepository = leagueRepository;
        }

        public async Task<Season> AddAsync(SeasonDTO model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }

            var league = await leagueRepository.GetAsyncById(model.LeagueID);

            if (league == null)
            {
                throw new KeyNotFoundException("League can't be null");
            }

            var season = new Season()
            {
                Name = model.Name,
                Number=model.Number,
                League = league
            };

            return await seasonRepository.AddAsync(season);
        }

        public async Task DeleteAsync(int id)
        {
            var seasonDelete = await seasonRepository.GetAsyncById(id);
            if (seasonDelete == null)
            {
                throw new KeyNotFoundException("No Season ");
            }
            await seasonRepository.DeleteAsync(id);
        }

        public async Task<List<Season>> GetAll()
        {
            var result = await seasonRepository.GetAll();
            return result;
        }

        public async Task<List<Season>> GetAllSeasons()
        {
            var result = await seasonRepository.GetAllSet();
            return result.Include(x => x.League).ThenInclude(r=>r.Teams).ToList();
        }

        public async Task<Season> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id must be bigger than 0");
            }
            var result = await seasonRepository.GetAllSet();
            var season= await result.Include(x => x.League).FirstOrDefaultAsync();
            //var result = await seasonRepository.GetAsyncById(id);
            return season;
        }

        public async Task<Season> UpdateAsync(Season model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }

            return await seasonRepository.UpdateAsync(model);
        }
    }
}
