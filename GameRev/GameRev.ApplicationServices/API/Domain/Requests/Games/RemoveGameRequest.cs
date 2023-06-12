using GameRev.ApplicationServices.API.Domain.Responses.Games;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Games
{
    public class RemoveGameRequest : RequestBase, IRequest<RemoveGameResponse>
    {
        public int Id { get; set; }
    }
}
