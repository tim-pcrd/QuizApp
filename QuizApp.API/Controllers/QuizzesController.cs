using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.API.Helpers;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUserQuery;
using QuizApp.Application.Helpers;
using System;
using System.Threading.Tasks;

namespace QuizApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizzesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<QuizListByUserVm>>> GetQuizzes([FromQuery]PaginationParams paginationParams)
        {
            var quizzes = await _mediator.Send(new GetQuizzesByUser.Query(paginationParams.PageIndex, paginationParams.PageSize, 
                Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")));
            return Ok(quizzes);
        }
    }
}
