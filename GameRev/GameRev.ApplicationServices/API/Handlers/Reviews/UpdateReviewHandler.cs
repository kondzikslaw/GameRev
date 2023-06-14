using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.ErrorHandling;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Queries.Reviews;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewRequest, UpdateReviewResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IQueryExecutor _queryExecutor;

        private readonly IMapper _mapper;

        public UpdateReviewHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        public async Task<UpdateReviewResponse> Handle(UpdateReviewRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewQuery
            {
                Id = request.Id
            };

            var review = await _queryExecutor.Execute(query);

            if (review is null)
            {
                return new UpdateReviewResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedReview = _mapper.Map<Review>(request);

            var command = new UpdateReviewCommand()
            {
                Parameter = mappedReview
            };

            var updatedCommand = await _commandExecutor.Execute(command);

            return new UpdateReviewResponse
            {
                Data = _mapper.Map<Domain.Models.Review>(updatedCommand)
            };
        }
    }
}
