using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class GetReviewsRequest : RequestBase, IRequest<GetReviewsResponse>
    {
        public int GameId { get; set; }
    }
}
