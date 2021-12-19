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
    [Route("api/Player")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPlayers()
        {
            return Ok(await playerService.GetAllPlayers());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPlayerById(int id)
        {
            return Ok(await playerService.GetAsyncById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddPlayer(PlayerDTO player)
        {
            return Ok(await playerService.AddAsync(player));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            await playerService.DeleteAsync(id);
            return Ok();
        }
    }
}
