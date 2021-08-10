using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.API.Helpers;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser;
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
        public async Task<ActionResult<Pagination<GetQuizzesByUserVm>>> GetQuizzes([FromQuery]PaginationParams paginationParams)
        {

            //TODO check userId
            var quizzes = await _mediator.Send(new GetQuizzesByUserQuery(paginationParams.PageIndex, paginationParams.PageSize, 
                Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")));

            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuizDetailsVm>> GetQuiz(int id)
        {
            //TODO check userId
            var quiz = await _mediator.Send(new GetQuizDetailsQuery { Id = id });

            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz(CreateQuizCommand createQuizCommand)
        {
            var response = await _mediator.Send(createQuizCommand);

            return Ok(response);
        } 
    }
}
