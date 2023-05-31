using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.CQRS.Commands.Reviews;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class AddReviewsHandler : IRequestHandler<AddReviewsRequest, AddReviewsResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IMapper _mapper;

        public AddReviewsHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }
        public async Task<AddReviewsResponse> Handle(AddReviewsRequest request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request);
            var command = new AddReviewCommand() { Parameter = review };
            var reviewFromDb = await _commandExecutor.Execute(command);
            return new AddReviewsResponse()
            {
                Data = _mapper.Map<Domain.Models.Review>(reviewFromDb)
            };
        }
    }
}
