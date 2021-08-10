using Microsoft.AspNetCore.Http;
using QuizApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.API
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            //TODO get claim
            UserId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        }

        public Guid UserId { get; }
    }
}
