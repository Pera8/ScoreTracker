using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Repository.Models;
using ScoreTracker2.Localize;
using ScoreTracker2.Loggers;
using Service;
using Shared.DTO;
using System.Threading.Tasks;

namespace ScoreTracker2.Controllers
{
    [Route("api/auth")]
    [Route("{culture:culture}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly AuthTokenService authTokenService;
        private readonly AuthService authService;
        private readonly ILogger<AuthController> _logger;
        private readonly IStringLocalizer<Resource.Localize.Resource> localizer;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, 
            AuthTokenService authTokenService, AuthService authService, ILogger<AuthController> logger,
            IStringLocalizer<Resource.Localize.Resource> localizer)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authTokenService = authTokenService;
            this.authService = authService;
            this._logger = logger;
            this.localizer = localizer;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var a = localizer["About"];
            return Ok(localizer["About"]);
            var result = await authService.RegisterUserAuth(registerUser);
            return Ok(result);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginUser loginParam)
        {
            var result = await authService.LoginUserAuth(loginParam);
            _logger.LogDebug("Weather forecast ready!");
            return Ok(result);
        }
    }
}
