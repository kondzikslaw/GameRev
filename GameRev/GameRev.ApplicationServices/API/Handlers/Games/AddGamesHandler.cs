﻿using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands.Games;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Games
{
    public class AddGamesHandler : IRequestHandler<AddGamesRequest, AddGamesResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IMapper _mapper;

        public AddGamesHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }
        public async Task<AddGamesResponse> Handle(AddGamesRequest request, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(request);
            var command = new AddGameCommand() { Parameter = game };
            var gameFromDb = await _commandExecutor.Execute(command);
            return new AddGamesResponse()
            {
                Data = _mapper.Map<Domain.Models.Game>(gameFromDb)
            };
        }
    }
}
