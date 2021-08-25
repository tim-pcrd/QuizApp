using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.API.Errors;
using QuizApp.Application.Interfaces.Identity;
using QuizApp.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IMediator _mediator;

        public AccountController(IAuthenticationService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (!result.Success) return Unauthorized(new ApiResponse(401,result.Error));


            return Ok(result.Response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            if (!result.Success)
            {
                return BadRequest(new ApiValidationErrorResponse(400) { Errors = result.Errors });
            }

            return Ok(result.Response);
        }

    }
}
