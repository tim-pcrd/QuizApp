using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Identity;
using QuizApp.Application.Models.Identity;
using QuizApp.Identity.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IValidation<RegistrationRequest, RegistrationRequestValidator> _registrationValidation;

        public AuthenticationService(
            IConfiguration config,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IValidation<RegistrationRequest, RegistrationRequestValidator> registrationValidation)
        {
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
            _registrationValidation = registrationValidation;
        }

        public async Task<(bool Success, LoginResponse Response, string Error)> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null) return (Success:false, Response: null, Error: "Invalid login attempt.");

            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                return (Success: false, Response: null, Error:"Email address is not verified.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) return (Success: false, Response: null, Error: "Invalid login attempt.");

            var response = new LoginResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = GenerateToken(user)
            };

            return (Success: true, Response: response, Error: null);
        }

        public async Task<(bool Success, RegistrationResponse Response, IEnumerable<string> Errors)> RegisterAsync(RegistrationRequest request)
        {
            //TODO change language
            _registrationValidation.Validate(request);

            //TODO email confirmation
            var user = new ApplicationUser
            {
                Email = request.Email,
                EmailConfirmed = true,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return (Success: false, Response: null, Errors: errors);
            }

            var response = new RegistrationResponse
            {
                UserId = user.Id
            };

            return (Success:true, Response: response, Errors: null);
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("uid", user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_config["JwtSettings:DurationInMinutes"])),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
