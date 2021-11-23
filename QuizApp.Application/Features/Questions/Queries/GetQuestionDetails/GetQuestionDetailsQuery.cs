using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Queries.GetQuestionDetails
{
    public class GetQuestionDetailsQuery : IRequest<QuestionDetailsVm>
    {
        public GetQuestionDetailsQuery(int questionId)
        {
            QuestionId = questionId;
        }

        public int QuestionId { get; }
    }
}
