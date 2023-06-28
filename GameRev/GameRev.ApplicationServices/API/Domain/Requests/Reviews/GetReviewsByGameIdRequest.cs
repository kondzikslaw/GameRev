using GameRev.ApplicationServices.API.Domain.Responses.Reviews;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Reviews
{
    public class GetReviewsByGameIdRequest : RequestBase, IRequest<GetReviewsByGameIdResponse>
    {
        public int GameId { get; set; }
    }
}
