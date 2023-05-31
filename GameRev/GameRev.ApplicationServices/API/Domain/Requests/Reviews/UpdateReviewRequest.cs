using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class UpdateReviewRequest : IRequest<UpdateReviewResponse>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public double Rate { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }


    }
}
