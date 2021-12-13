using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.API.Helpers;
using QuizApp.Application.Features.Questions.Commands.CreateQuestion;
using QuizApp.Application.Features.Questions.Commands.DeleteQuestion;
using QuizApp.Application.Features.Questions.Commands.UpdateQuestion;
using QuizApp.Application.Features.Questions.Queries.GetQuestionDetails;
using QuizApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggedInUserService _loggedInUserService;

        public QuestionsController(IMediator mediator, ILoggedInUserService loggedInUserService)
        {
            _mediator = mediator;
            _loggedInUserService = loggedInUserService;
        }

        // TODO check user
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDetailsVm>> Get(int id)
        {
            var result = await _mediator.Send(new GetQuestionDetailsQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateReponse>> Create(CreateQuestionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new CreateReponse { Id = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateQuestionCommand command)
        {
            if (id != command.Id) return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteQuestionCommand(id));

            return NoContent();
        }

    }
}
