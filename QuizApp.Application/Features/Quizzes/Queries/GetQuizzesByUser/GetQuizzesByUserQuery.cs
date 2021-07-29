using MediatR;
using QuizApp.Application.Helpers;
using System;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser
{
    public class GetQuizzesByUserQuery : IRequest<Pagination<GetQuizzesByUserVm>>
    {
        public GetQuizzesByUserQuery(int pageIndex, int pageSize, Guid accountId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            AccountId = accountId;
        }

        public int PageIndex { get; }
        public int PageSize { get; }

        public Guid AccountId { get; }
    }

}
