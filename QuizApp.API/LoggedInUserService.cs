using MediatR;
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
            //TODO get username claim
            UserName = "Tim";
        }

        public string UserName { get; }


    }
}
