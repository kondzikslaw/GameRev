using GameRev.ApplicationServices.API.Domain.Responses;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
    }
}
