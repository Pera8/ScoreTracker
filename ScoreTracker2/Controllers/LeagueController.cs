using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreTracker2.Controllers
{
    [Route("api/League")]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LeagueController : ControllerBase

    {
        private readonly ILeagueService leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLeagues()
        {
            return Ok(await leagueService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetLeagueById(int id)
        {
            return Ok(await leagueService.GetAsyncById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddLeague(League league)
        {
            return Ok(await leagueService.AddAsync(league));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLeague(int id)
        {
            await leagueService.DeleteAsync(id);
            return Ok();
        }
    }
}
