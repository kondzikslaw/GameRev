using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.ApplicationServices.API.Domain.Requests.Reviews;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Reviews;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Queries;
using GameRev.DataAccess.CQRS.Queries.Reviews;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetReviewsByGameIdHandler : IRequestHandler<GetReviewsByGameIdRequest, GetReviewsByGameIdResponse>
    {
        private readonly IMapper _mapper;

        private readonly IQueryExecutor _queryExecutor;

        public GetReviewsByGameIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetReviewsByGameIdResponse> Handle(GetReviewsByGameIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewsQuery()
            {
                GameId = request.GameId
            };
            var review = await _queryExecutor.Execute(query);
            var mappedReview = _mapper.Map<List<Domain.Models.Review>>(review);
            var response = new GetReviewsByGameIdResponse()
            {
                Data = mappedReview
            };
            return response;
        }
    }
}
