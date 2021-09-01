using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest
    {
        public DeleteQuestionCommand(int questionId)
        {
            QuestionId = questionId;
        }

        public int QuestionId { get; }
    }
}
