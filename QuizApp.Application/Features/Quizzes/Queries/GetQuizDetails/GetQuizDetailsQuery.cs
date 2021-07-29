using MediatR;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails
{

    public class GetQuizDetailsQuery : IRequest<GetQuizDetailsVm>
    {
        public int Id { get; set; }
    }

}
