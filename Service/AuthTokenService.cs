using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using Service.Configuration;
using Shared.DTOLight;
using Shared.Helper;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthTokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;
        //private readonly RoleManager<Role> _roleManager;

        static AuthTokenService() => MapperConfig.RegisterUserMapping();

        public AuthTokenService(UserManager<User> _userManager, SignInManager<User> _signInManager, IOptions<AppSettings> _appSettings)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this._appSettings = _appSettings.Value;
        }

        public async Task<AuthDto> Authenticate(string email, string password, bool remeberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && user.EmailConfirmed)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);
                if (result.Succeeded)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var expireTime = remeberMe ? _appSettings.JwtDurationInHoursLong : _appSettings.JwtDurationInHoursShort;
                    JwtSecurityToken tokenOptions;

                    tokenOptions = new JwtSecurityToken(
                                            issuer: _appSettings.BaseUrl,
                                            audience: _appSettings.BaseUrl,
                                            expires: DateTime.Now.AddHours(expireTime),
                                            signingCredentials: signinCredentials
                                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    var auth = new AuthDto { Token = tokenString, UserAuth = TypeAdapter.Adapt<User, UserAuth>(user) };
                    return await Task.FromResult(auth);
                }
            }

            return null;
        }
    }
}
