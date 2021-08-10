using MediatR;
using QuizApp.Application.Helpers;
using System;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser
{
    public class GetQuizzesByUserQuery : IRequest<Pagination<GetQuizzesByUserVm>>
    {
        public GetQuizzesByUserQuery(int pageIndex, int pageSize, Guid playerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            PlayerId = playerId;
        }

        public int PageIndex { get; }
        public int PageSize { get; }

        public Guid PlayerId { get; }
    }

}
