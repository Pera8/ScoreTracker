using Microsoft.AspNetCore.Identity;
using Repository.Models;
using Shared.DTO;
using Shared.DTOLight;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly AuthTokenService authTokenService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, AuthTokenService authTokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authTokenService = authTokenService;
        }

        public async Task<User> RegisterUserAuth(RegisterUser registerUser)
        {
            var user = new User
            {
                Name= registerUser.Name,
                UserName = registerUser.Name,
                Email = registerUser.Email,
                Phone=registerUser.Phone,
            };

            var result = await userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException();
            }
            return user;
        }

        public async Task<AuthDto> LoginUserAuth(LoginUser loginParam)
        {
            if (loginParam == null)
                throw new UnauthorizedAccessException();
            var auth = await authTokenService.Authenticate(loginParam.Email, loginParam.Password, loginParam.RememberMe);
            // auth.Wait();
            if (auth == null)
            {
                throw new ArgumentException("Email or password are incorrect");
            }
            return auth;
        }
    }
}
