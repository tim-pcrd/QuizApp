using MediatR;
using QuizApp.Application.Helpers;
using System;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser
{
    public class GetQuizzesByUserQuery : IRequest<Pagination<GetQuizzesByUserVm>>
    {
        public GetQuizzesByUserQuery(int pageIndex, int pageSize, string userName)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            UserName = userName;
        }

        public int PageIndex { get; }
        public int PageSize { get; }

        public string UserName { get; }
    }

}
