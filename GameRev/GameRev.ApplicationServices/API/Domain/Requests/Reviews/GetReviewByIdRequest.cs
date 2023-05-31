using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class GetReviewByIdRequest : IRequest<GetReviewByIdResponse>
    {
        public int ReviewId { get; set; }
    }
}
