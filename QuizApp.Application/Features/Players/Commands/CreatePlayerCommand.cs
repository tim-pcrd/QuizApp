using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Players.Commands
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public CreatePlayerCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }

    public class CreatePlayerCommandValidator: AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator(IDbContext context)
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(20)
                .MustAsync(async(userName, cancellation) 
                    => !(await context.Players.AnyAsync(x => x.UserName.ToLower() == userName.ToLower())))
                .WithMessage("{PropertyName} bestaat al");
                
        }
    }
}
