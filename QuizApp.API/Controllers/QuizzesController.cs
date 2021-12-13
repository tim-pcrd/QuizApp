using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.API.Helpers;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Features.Quizzes.Commands.DeleteQuiz;
using QuizApp.Application.Features.Quizzes.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quizzes.Commands.UpdateQuizStatus;
using QuizApp.Application.Features.Quizzes.Queries.CheckNameExists;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuizApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggedInUserService _loggedInUserService;

        public QuizzesController(IMediator mediator, ILoggedInUserService loggedInUserService)
        {
            _mediator = mediator;
            _loggedInUserService = loggedInUserService;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<GetQuizzesByUserVm>>> GetQuizzes([FromQuery] PaginationParams paginationParams)
        {
            //TODO check userId
            var quizzes = await _mediator.Send(new GetQuizzesByUserQuery(paginationParams.PageIndex, paginationParams.PageSize,
                _loggedInUserService.UserName));

            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuizDetailsVm>> GetQuiz(int id)
        {
            //TODO check userId
            var quiz = await _mediator.Send(new GetQuizDetailsQuery(id, _loggedInUserService.UserName));

            return Ok(quiz);
        }

        [HttpGet("nameexists")]
        public async Task<ActionResult<bool>> CheckNameExists(string name)
        {
            var result = await _mediator.Send(new CheckNameExistsQuery(name));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuizCommand createQuizCommand)
        {
            var result = await _mediator.Send(createQuizCommand);

            return Ok(new CreateReponse { Id = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateQuizCommand command)
        {
            if (id != command.Id) return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteQuizCommand(id));

            return NoContent();
        }

        [HttpPost("{id}/updatestatus")]
        public async Task<IActionResult> UpdateQuizStatus(int id, UpdateQuizStatusCommand command)
        {
            if (id != command.QuizId) return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
