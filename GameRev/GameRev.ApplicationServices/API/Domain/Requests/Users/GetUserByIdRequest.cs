using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
