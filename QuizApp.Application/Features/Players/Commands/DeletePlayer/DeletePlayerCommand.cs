using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommand : IRequest
    {
        public DeletePlayerCommand(int playerId)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; }
    }
}
