using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Reviews;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetReviewsHandler : IRequestHandler<GetReviewsRequest, GetReviewsResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetReviewsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;

        }

        public async Task<GetReviewsResponse> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewsQuery();
            var reviews = await _queryExecutor.Execute(query);
            var mappedReview = _mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewsResponse()
            {
                Data = mappedReview
            };
            return response;

        }
    }
}
