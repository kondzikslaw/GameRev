using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class RemoveReviewRequest : RequestBase, IRequest<RemoveReviewResponse>
    {
        public int Id { get; set; }
    }
}
