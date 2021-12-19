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
    [Route("api/Season")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService seasonService;
        public SeasonController(ISeasonService seasonService)
        {
            this.seasonService = seasonService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSeasons()
        {
            return Ok(await seasonService.GetAllSeasons());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetSeasonById(int id)
        {
            return Ok(await seasonService.GetAsyncById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddSeason(SeasonDTO season)
        {
            return Ok(await seasonService.AddAsync(season));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSeason(int id)
        {
            await seasonService.DeleteAsync(id);
            return Ok();
        }
    }
}
