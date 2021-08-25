using MediatR;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails
{

    public class GetQuizDetailsQuery : IRequest<GetQuizDetailsVm>
    {
        public GetQuizDetailsQuery(int id, string userName)
        {
            Id = id;
            UserName = userName;
        }
        public int Id { get; }
        public string UserName { get; }
    }

}
