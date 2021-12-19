using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interface;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreTracker2.Controllers
{
    [Route("api/Team")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;
        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTeams()
        {
            return Ok(await teamService.GetAllTeam());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTeamById(int id)
        {
            return Ok(await teamService.GetAsyncById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddTeam(TeamDTO team)
        {
            return Ok(await teamService.AddAsync(team));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await teamService.DeleteAsync(id);
            return Ok();
        }
    }
}
