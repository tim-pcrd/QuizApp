using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Players.Queries.CheckPlayerExistence
{
    public class CheckPlayerExistenceQuery : IRequest<bool>
    {
        public CheckPlayerExistenceQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
