using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class RemoveReviewRequest : IRequest<RemoveReviewResponse>
    {
        public int Id { get; set; }
    }
}
