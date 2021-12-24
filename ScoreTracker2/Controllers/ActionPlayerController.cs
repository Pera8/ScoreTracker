using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreTracker2.Controllers
{

    [Route("api/ActionPlayer")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActionPlayerController : ControllerBase
    {
        private readonly IActionPlayerSevice actionPlayerService;
        public ActionPlayerController(IActionPlayerSevice actionPlayerService)
        {
            this.actionPlayerService = actionPlayerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllActionPlayers()
        {
            return Ok(await actionPlayerService.GetAllActionPlayers());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetActionPlayerById(int id)
        {
            return Ok(await actionPlayerService.GetAsyncById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddActionPlayer(ActionPlayerDTO player)
        {
            return Ok(await actionPlayerService.AddAsync(player));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteActionPlayer(int id)
        {
            await actionPlayerService.DeleteAsync(id);
            return Ok();
        }

    }
}
