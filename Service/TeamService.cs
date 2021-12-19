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
    public class TeamService : ITeamService
    {
        static TeamService() => MapperConfig.RegisterTeamMapping();
        private readonly IRepository<Team> teamRepository;
        private readonly IRepository<League> leagueRepository;

        public TeamService(IRepository<Team> teamRepository, IRepository<League> leagueRepository)
        {
            this.teamRepository = teamRepository;
            this.leagueRepository = leagueRepository;
        }
        public TeamService(IRepository<Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public async Task<Team> AddAsync(TeamDTO model)
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

            var teamDao = new Team()
            {
                Name = model.Name,
                Address=model.Address,
                Logo=model.Logo,
                League=league             
            };

            return await teamRepository.AddAsync(teamDao);
        }

        public async Task DeleteAsync(int id)
        {
            var teamDelete = await teamRepository.GetAsyncById(id);
            if (teamDelete == null)
            {
                throw new KeyNotFoundException("No team ");
            }
            await teamRepository.DeleteAsync(id);
        }

        public async Task<List<Team>> GetAll()
        {
            var result = await teamRepository.GetAll();
            return result;
        }

        public async Task<List<Team>> GetAllTeam()
        {
            var result = await teamRepository.GetAllSet();
            return result.Include(x => x.League).ToList();
        }

        public async Task<Team> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id must be bigger than 0");
            }
            var rez = await teamRepository.GetAllSet();
            var team= await rez.Include(x => x.League).Where(r => r.Id == id).FirstOrDefaultAsync();
            //var result = await teamRepository.GetAsyncById(id);
            return team;
        }

        public async Task<Team> UpdateAsync(Team model)
        {
            if (model == null)
            {
                throw new ArgumentException();
            }

            return await teamRepository.UpdateAsync(model);
        }

        public Task<Team> AddAsync(Team model)
        {
            throw new NotImplementedException();
        }
    }
}
