using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizDetailsQuery
{
    public class GetQuizDetails
    {
        public class Query: IRequest<QuizDetailsVm> 
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, QuizDetailsVm>
        {
            public Task<QuizDetailsVm> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}
