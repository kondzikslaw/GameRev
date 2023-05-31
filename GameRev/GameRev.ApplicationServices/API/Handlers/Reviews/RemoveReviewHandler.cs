using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Reviews;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class RemoveReviewHandler : IRequestHandler<RemoveReviewRequest, RemoveReviewResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        public RemoveReviewHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveReviewResponse> Handle(RemoveReviewRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewQuery()
            {
                Id = request.Id
            };

            var getReview = await _queryExecutor.Execute(query);

            var mappedReview = _mapper.Map<Review>(getReview);
            var command = new RemoveReviewCommand()
            {
                Parameter = mappedReview
            };

            var removedCommand = await _commandExecutor.Execute(command);

            return new RemoveReviewResponse()
            {
                Data = removedCommand
            };
        }
    }
}
