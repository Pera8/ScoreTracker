using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using Shared.DTO;
using System.Threading.Tasks;

namespace ScoreTracker2.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly AuthTokenService authTokenService;
        private readonly AuthService authService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, AuthTokenService authTokenService, AuthService authService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authTokenService = authTokenService;
            this.authService = authService;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var result = await authService.RegisterUserAuth(registerUser);
            return Ok(result);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginUser loginParam)
        {
            var result = await authService.LoginUserAuth(loginParam);
            return Ok(result);
        }
    }
}
