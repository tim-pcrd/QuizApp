using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommand : IRequest
    {
        public DeleteQuizCommand(int quizId)
        {
            QuizId = quizId;
        }

        public int QuizId { get; }
    }
}
