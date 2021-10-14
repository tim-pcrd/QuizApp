using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.CheckNameExists
{
    public class CheckNameExistsQuery : IRequest<bool>
    {
        public CheckNameExistsQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
