﻿using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Games;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Games
{
    public class GetGameByIdHandler : IRequestHandler<GetGameByIdRequest, GetGameByIdResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetGameByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetGameByIdResponse> Handle(GetGameByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGameQuery()
            {
                Id = request.Id
            };
            var game = await _queryExecutor.Execute(query);

            if (game == null)
            {
                return new GetGameByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedGame = _mapper.Map<Domain.Models.Game>(game);
            var response = new GetGameByIdResponse()
            {
                Data = mappedGame
            };
            return response;
        }
    }
}
