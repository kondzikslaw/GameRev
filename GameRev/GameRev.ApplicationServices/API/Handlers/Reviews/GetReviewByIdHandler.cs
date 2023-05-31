using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Reviews;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdRequest, GetReviewByIdResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetReviewByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetReviewByIdResponse> Handle(GetReviewByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewQuery()
            {
                Id = request.ReviewId
            };
            var review = await _queryExecutor.Execute(query);
            var mappedReview = _mapper.Map<Domain.Models.Review>(review);
            var response = new GetReviewByIdResponse()
            {
                Data = mappedReview
            };
            return response;
        }
    }
}
