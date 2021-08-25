using AutoMapper;
using MediatR;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Players.Commands
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IValidation<CreatePlayerCommand, CreatePlayerCommandValidator> _validation;
        private readonly IMapper _mapper;

        public CreatePlayerCommandHandler(
            IDbContext context, 
            IValidation<CreatePlayerCommand, CreatePlayerCommandValidator> validation,
            IMapper mapper)
        {
            _context = context;
            _validation = validation;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            //TODO image handling
            await _validation.ValidateAsync(request);

            var player = _mapper.Map<Player>(request);

            _context.Players.Add(player);
            await _context.SaveChangesAsync(cancellationToken);

            return player.Id;
        }
    }
}
