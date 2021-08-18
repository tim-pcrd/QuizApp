using MediatR;
using Microsoft.AspNetCore.Http;
using QuizApp.Application.Features.Players.Queries;
using QuizApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.API
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        public async Task<int> GetPlayerId()
        {
            //TODO get username claim
            return await _mediator.Send(new GetPlayerIdByUserNameQuery("Tim"));
        }
    }
}
